using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace DefinitiefProgram
{
    public partial class ctb : UserControl { public ctb() { } }
    public class CustomMaskedTextbox : Control
    {
        public enum MouseState : byte
        {
            None,
            Over,
            Down
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never), AccessedThroughProperty("TB"), CompilerGenerated]
        private MaskedTextBox _TB;

        private Graphics G;

        private XylosTextBox.MouseState State;

        private bool _EnabledCalc;

        private bool _allowpassword;

        private int _maxChars;

        private HorizontalAlignment _textAlignment;

        private bool _multiLine;

        private bool _readOnly;

        public virtual MaskedTextBox TB
        {
            [CompilerGenerated]
            get
            {
                return this._TB;
            }
            [CompilerGenerated]
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler value2 = delegate (object a0, EventArgs a1)
                {
                    this.TextChangeTb();
                };
                MaskedTextBox tB = this._TB;
                if (tB != null)
                {
                    tB.TextChanged -= value2;
                }
                this._TB = value;
                tB = this._TB;
                if (tB != null)
                {
                    tB.TextChanged += value2;
                }
            }
        }

        public string Mask
        {
            get { return TB.Mask; }
            set { TB.Mask = value; base.Invalidate(); }
        }

        public new bool Enabled
        {
            get { return this.EnabledCalc; }
            set
            {
                this.TB.Enabled = value;
                this._EnabledCalc = value;
                base.Invalidate();
            }
        }

        [DisplayName("Enabled")]
        public bool EnabledCalc
        {
            get { return this._EnabledCalc; }
            set
            {
                this.Enabled = value;
                base.Invalidate();
            }
        }

        public bool UseSystemPasswordChar
        {
            get { return this._allowpassword; }
            set
            {
                this.TB.UseSystemPasswordChar = this.UseSystemPasswordChar;
                this._allowpassword = value;
                base.Invalidate();
            }
        }

        public int MaxLength
        {
            get { return this._maxChars; }
            set
            {
                this._maxChars = value;
                this.TB.MaxLength = this.MaxLength;
                base.Invalidate();
            }
        }

        public HorizontalAlignment TextAlign
        {
            get { return this._textAlignment; }
            set
            {
                this._textAlignment = value;
                base.Invalidate();
            }
        }

        public bool MultiLine
        {
            get { return this._multiLine; }
            set
            {
                this._multiLine = value;
                this.TB.Multiline = value;
                this.OnResize(EventArgs.Empty);
                base.Invalidate();
            }
        }

        public bool ReadOnly
        {
            get { return this._readOnly; }
            set
            {
                this._readOnly = value;
                bool flag = this.TB != null;
                if (flag) { this.TB.ReadOnly = value; }
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            base.Invalidate();
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            base.Invalidate();
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            this.TB.ForeColor = this.ForeColor;
            base.Invalidate();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            this.TB.Font = this.Font;
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            this.TB.Focus();
        }

        private void TextChangeTb()
        { this.Text = this.TB.Text; }

        private void TextChng()
        { this.TB.Text = this.Text; }

        public void NewTextBox()
        {
            MaskedTextBox tB = this.TB;
            tB.Text = string.Empty;
            tB.BackColor = Color.White;
            tB.ForeColor = Helpers.ColorFromHex("#7C858E");
            tB.TextAlign = HorizontalAlignment.Left;
            tB.BorderStyle = BorderStyle.None;
            tB.Location = new Point(3, 3);
            tB.Font = new Font("Segoe UI", 9f);
            tB.Size = checked(new Size(base.Width - 3, base.Height - 3));
            tB.UseSystemPasswordChar = this.UseSystemPasswordChar;
        }

        public CustomMaskedTextbox()
        {
            base.TextChanged += delegate (object a0, EventArgs a1)
            { this.TextChng(); };
            this.TB = new MaskedTextBox();
            this._allowpassword = false;
            this._maxChars = 32767;
            this._multiLine = false;
            this._readOnly = false;
            this.NewTextBox();
            base.Controls.Add(this.TB);
            base.SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            this.DoubleBuffered = true;
            this.TextAlign = HorizontalAlignment.Left;
            this.ForeColor = Helpers.ColorFromHex("#7C858E");
            this.Font = new Font("Segoe UI", 9f);
            base.Size = new Size(130, 29);
            this.Enabled = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.G = e.Graphics;
            this.G.SmoothingMode = SmoothingMode.HighQuality;
            this.G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            base.OnPaint(e);
            this.G.Clear(Color.White);
            bool enabled = this.Enabled;
            if (enabled)
            {
                this.TB.ForeColor = Helpers.ColorFromHex("#7C858E");
                bool flag = this.State == XylosTextBox.MouseState.Down;
                if (flag)
                {
                    using (Pen pen = new Pen(Helpers.ColorFromHex("#78B7E6")))
                    { this.G.DrawPath(pen, Helpers.RoundRect(Helpers.FullRectangle(base.Size, true), 12, Helpers.RoundingStyle.All)); }
                }
                else
                {
                    using (Pen pen2 = new Pen(Helpers.ColorFromHex("#D0D5D9")))
                    { this.G.DrawPath(pen2, Helpers.RoundRect(Helpers.FullRectangle(base.Size, true), 12, Helpers.RoundingStyle.All)); }
                }
            }
            else
            {
                this.TB.ForeColor = Helpers.ColorFromHex("#7C858E");
                using (Pen pen3 = new Pen(Helpers.ColorFromHex("#E1E1E2")))
                { this.G.DrawPath(pen3, Helpers.RoundRect(Helpers.FullRectangle(base.Size, true), 12, Helpers.RoundingStyle.All)); }
            }
            this.TB.TextAlign = this.TextAlign;
            this.TB.UseSystemPasswordChar = this.UseSystemPasswordChar;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            bool flag = !this.MultiLine;
            checked
            {
                if (flag)
                {
                    int height = this.TB.Height;
                    this.TB.Location = new Point(10, (int)Math.Round(unchecked((double)base.Height / 2.0 - (double)height / 2.0 - 0.0)));
                    this.TB.Size = new Size(base.Width - 20, height);
                }
                else
                {
                    this.TB.Location = new Point(10, 10);
                    this.TB.Size = new Size(base.Width - 20, base.Height - 20);
                }
            }
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            this.State = XylosTextBox.MouseState.Down;
            base.Invalidate();
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            this.State = XylosTextBox.MouseState.None;
            base.Invalidate();
        }
    }
}