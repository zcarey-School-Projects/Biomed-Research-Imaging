using SpinnakerNET.GenApi;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UndergradResearchBiomedImaging.Flir;
using UndergradResearchBiomedImaging.Flir.Nodes;
using UndergradResearchBiomedImaging.Util;

namespace UndergradResearchBiomedImaging.UI.Options {
	public abstract class OptionEntry<ControlType, TNode, NodeType, ValueType> : IOptionEntry where ControlType : Control where NodeType : INode where TNode : BaseNode<NodeType, ValueType> {

		private const int ControlXPos = 114;

		private readonly object ControlLock = new object();
		private Label entryLabel;
		private ControlType entryControl;
		private bool ignoreValueChanged = false;

		private Property<FlirCamera, TNode> cameraProperty;

		private ImageStream input;

		public override int Height { get; protected set; } = 28;

		public OptionEntry(string name, Property<FlirCamera, TNode> property, ImageStream input) {
			this.input = input;
			this.cameraProperty = property;

			entryLabel = new Label();
			entryLabel.Text = name + ": ";
			entryLabel.Location = new Point(3, 5);

			entryControl = generateControl(ControlXPos);
			invokeAction(new Action(() => {
				addValueChangedEvent(entryControl, OnValueChangedEvent);
			}));

			Update();
		}

		protected abstract ControlType generateControl(int xPos);

		public override void DrawControls(int yPos) {
			lock (ControlLock) {
				invokeAction(new Action(() => {
					entryLabel.Location = new Point(entryLabel.Location.X, yPos + 5);
					entryControl.Location = new Point(entryControl.Location.X, yPos + 3);
				}));
			}
		}

		protected override void OnPanelChanged(OptionsPanel newPanel) {
			lock (ControlLock) {
				invokeAction(new Action(() => {
					entryLabel.Parent = newPanel.getPanel();
					entryControl.Parent = newPanel.getPanel();
					entryControl.BringToFront();
				}));
			}
		}

		protected abstract void addValueChangedEvent(ControlType entryControl, EventHandler eventHandler);

		private void OnValueChangedEvent(object sender, EventArgs args) {
			lock (ControlLock) {
				if (ignoreValueChanged) return;
				SetValue(getCurrentValue(entryControl));
			}
		}

		protected abstract ValueType getCurrentValue(ControlType entryControl); //Usually called by OnValueChangedEvent to get the new, updated value.

		protected abstract void SetControlValue(ControlType entryControl, ValueType newValue); //Sets the controls value/selection to the given value

		private void SetValue(ValueType newValue) {
			lock (ControlLock) {
				TNode node = getNode();
				if (node == null || !node.TrySetValue(newValue)) {
					Enabled = false;
				}

				GetValue(); //Attemps to read the value and display it.
			}
		}

		private void GetValue() { //Reads and displays current value from the camera.
			lock (ControlLock) {
				TNode node = getNode();
				ValueType value = default(ValueType);
				if (node != null && node.TryGetValue(ref value)) {
					ignoreValueChanged = true;
					invokeAction(new Action(() => { this.SetControlValue(entryControl, value); }));
					ignoreValueChanged = false;
				} else {
					ClearText(); //Clears text, indicating no value to read.
				}
				if (node != null && node.IsWritable()) {
					invokeAction(new Action(() => { checkValueLimits(entryControl, node); }));
					Enabled = true;
				} else {
					Enabled = false;
				}
			}
			
		}

		protected abstract void checkValueLimits(ControlType entryControl, TNode node);

		public override void Update() {
			lock (ControlLock) {
				GetValue();
			}
		}

		private TNode getNode() {
			lock (ControlLock) {
				if (input == null) return null;
				FlirCamera camera = input.camera;
				if (camera == null) return null;
				object val = null;
				if (!cameraProperty.TryGet(camera, ref val)) return null;
				if (val == null) return null;
				if (!(val is TNode)) return null;

				return (TNode)val;
			}
		}

		private bool Enabled { get => entryControl.Enabled; set => invokeAction(new Action(() => { entryControl.Enabled = value; })); }

		//protected string Text { get => entryControl.Text; set => entryControl.BeginInvoke(new Action(() => { entryControl.Text = value; })); }

		public void ClearText() {
			invokeAction(new Action(() => { entryControl.ResetText(); }));
		}

		private void invokeAction(Action act) {
			if (entryControl.InvokeRequired) {
				entryControl.Invoke(act);
			} else {
				act();
			}
		}

	}
}
