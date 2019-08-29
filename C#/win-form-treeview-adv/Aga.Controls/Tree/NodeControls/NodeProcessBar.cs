using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Aga.Controls.Tree.NodeControls
{
    public class NodeProcessBar : Tree.NodeControls.BindableControl
    {
        private static Graphics _measureGraphics = Graphics.FromImage(new Bitmap(1, 1));
        private StringFormat _format;
        private Pen _focusPen;

        #region Properties

        private Font _font = null;

        public Font Font
        {
            get
            {
                if (_font == null)
                    return Control.DefaultFont;
                else
                    return _font;
            }
            set
            {
                if (value == Control.DefaultFont)
                    _font = null;
                else
                    _font = value;
            }
        }

        public string ColorPerproty { get; set; }
        public string HidePerproty { get; set; }

        #endregion

        public NodeProcessBar()
        {
            _focusPen = new Pen(Color.Black);
            _focusPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

            _format = new StringFormat(StringFormatFlags.NoWrap | StringFormatFlags.NoClip |
                                       StringFormatFlags.FitBlackBox);
            _format.LineAlignment = StringAlignment.Center;
        }

        public override Size MeasureSize(TreeNodeAdv node)
        {
            return new Size(20, Font.Height);
        }

        public override void Draw(TreeNodeAdv node, DrawContext context)
        {
            var v = (double) GetValue(node);

            if (context.CurrentEditorOwner == this && node == Parent.CurrentNode)
                return;
            if (IsHide(node))
            {
                return;
            }

            var color = GetColor(node);
            DrawProcess(context, v, color);
            Rectangle clipRect = context.Bounds;
            Brush text = SystemBrushes.ControlText;

            string label = v.ToString("F1") + "%";
            Size s = GetLabelSize(label);
            Rectangle focusRect = new Rectangle(clipRect.X, clipRect.Y, s.Width, clipRect.Height);

            if (context.DrawSelection == DrawSelectionMode.Active)
            {
                text = SystemBrushes.HighlightText;
                context.Graphics.FillRectangle(SystemBrushes.Highlight, focusRect);
            }
            else if (context.DrawSelection == DrawSelectionMode.Inactive)
            {
                text = SystemBrushes.ControlText;
                context.Graphics.FillRectangle(SystemBrushes.InactiveBorder, focusRect);
            }
            else if (context.DrawSelection == DrawSelectionMode.FullRowSelect)
            {
                text = SystemBrushes.HighlightText;
            }

            if (!context.Enabled)
                text = SystemBrushes.GrayText;

            if (context.DrawFocus)
            {
                focusRect.Width--;
                focusRect.Height--;
                context.Graphics.DrawRectangle(Pens.Gray, focusRect);
                context.Graphics.DrawRectangle(_focusPen, focusRect);
            }

            DrawBorder(context);
            _format.Alignment = TextHelper.TranslateAligment(HorizontalAlignment.Center);
            //_format.Trimming = Trimming;
            clipRect.X += 5;
            clipRect.Y += 2;
            context.Graphics.DrawString(label, context.Font, text, clipRect, _format);
        }

        protected void DrawProcess(DrawContext context, double v, Color color)
        {
            var width = context.Bounds.Width - 4;
            width = Convert.ToInt32(width * v / width);
            var r = new Rectangle(context.Bounds.X + 2,
                context.Bounds.Y + 2,
                width,
                context.Bounds.Height - 4);

            context.Graphics.FillRectangle(new SolidBrush(color), r);
        }

        private Color GetColor(TreeNodeAdv node)
        {
            if (string.IsNullOrEmpty(ColorPerproty))
            {
                return Color.Aquamarine;
            }

            PropertyInfo pi = GetPropertyInfo(node, ColorPerproty);
            if (pi != null && pi.CanRead)
                return (Color) pi.GetValue(node.Tag, null);
            else
                return Color.Aquamarine;
        }

        private bool IsHide(TreeNodeAdv node)
        {
            if (string.IsNullOrEmpty(HidePerproty))
            {
                return false;
            }

            PropertyInfo pi = GetPropertyInfo(node, HidePerproty);
            if (pi != null && pi.CanRead)
                return (bool) pi.GetValue(node.Tag, null);
            else
                return true;
        }

        protected PropertyInfo GetPropertyInfo(TreeNodeAdv node, string prpertyName)
        {
            if (node.Tag != null && !string.IsNullOrEmpty(prpertyName))
            {
                Type type = node.Tag.GetType();
                return type.GetProperty(prpertyName);
            }

            return null;
        }

        protected void DrawBorder(DrawContext context)
        {
            var r = new Rectangle(context.Bounds.X + 2,
                context.Bounds.Y + 2,
                context.Bounds.Width - 4,
                context.Bounds.Height - 4);

            context.Graphics.DrawRectangle(Pens.Gray, r);
        }

        protected Size GetLabelSize(string label)
        {
            SizeF s = _measureGraphics.MeasureString(label, Font);
            if (!s.IsEmpty)
                return new Size((int) s.Width, (int) s.Height);
            else
                return new Size(10, Font.Height);
        }
    }
}