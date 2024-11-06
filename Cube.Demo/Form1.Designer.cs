namespace Cube.Demo
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnTransparency = new Button();
            btnChangeColor = new Button();
            btnChangeMode = new Button();
            openGLControl1 = new SharpGL.OpenGLControl();
            ((System.ComponentModel.ISupportInitialize)openGLControl1).BeginInit();
            SuspendLayout();
            // 
            // btnTransparency
            // 
            btnTransparency.Location = new Point(178, 12);
            btnTransparency.Name = "btnTransparency";
            btnTransparency.Size = new Size(145, 34);
            btnTransparency.TabIndex = 0;
            btnTransparency.Text = "Transparency";
            btnTransparency.UseVisualStyleBackColor = true;
            btnTransparency.Click += btnTransparency_Click;
            // 
            // btnChangeColor
            // 
            btnChangeColor.Location = new Point(329, 12);
            btnChangeColor.Name = "btnChangeColor";
            btnChangeColor.Size = new Size(112, 34);
            btnChangeColor.TabIndex = 1;
            btnChangeColor.Text = "Color";
            btnChangeColor.UseVisualStyleBackColor = true;
            btnChangeColor.Click += btnChangeColor_Click;
            // 
            // btnChangeMode
            // 
            btnChangeMode.Location = new Point(12, 12);
            btnChangeMode.Name = "btnChangeMode";
            btnChangeMode.Size = new Size(160, 34);
            btnChangeMode.TabIndex = 2;
            btnChangeMode.Text = "ChangeMode";
            btnChangeMode.UseVisualStyleBackColor = true;
            btnChangeMode.Click += btnChangeMode_Click;
            // 
            // openGLControl1
            // 
            openGLControl1.DrawFPS = false;
            openGLControl1.Location = new Point(12, 55);
            openGLControl1.Margin = new Padding(5, 6, 5, 6);
            openGLControl1.Name = "openGLControl1";
            openGLControl1.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            openGLControl1.RenderContextType = SharpGL.RenderContextType.DIBSection;
            openGLControl1.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            openGLControl1.Size = new Size(976, 898);
            openGLControl1.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1002, 968);
            Controls.Add(openGLControl1);
            Controls.Add(btnChangeMode);
            Controls.Add(btnChangeColor);
            Controls.Add(btnTransparency);
            Name = "Form1";
            Text = "Cube.Demo";
            ((System.ComponentModel.ISupportInitialize)openGLControl1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnTransparency;
        private Button btnChangeColor;
        private Button btnChangeMode;
        private SharpGL.OpenGLControl openGLControl1;
    }
}
