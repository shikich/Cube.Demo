using SharpGL.SceneGraph;
using SharpGL;
using System.Drawing;

namespace Cube.Demo
{
    public partial class Form1 : Form
    {
        private float _angleX = 0;
        private float _angleY = 0;
        private float _scale = 1;

        private bool _isTransparent = false;
        private bool _isFilled = true;
        private bool _isMouseDown = false;

        private float _lastMouseX;
        private float _lastMouseY;

        private GLColor _color;
        private GLColor _colorEdge;

        private System.Windows.Forms.Timer _renderTimer;

        public Form1()
        {
            InitializeComponent();

            openGLControl1.OpenGLDraw += openGLControl1_OpenGLDraw;
            openGLControl1.MouseDown += openGLControl1_MouseDown;
            openGLControl1.MouseMove += openGLControl1_MouseMove;
            openGLControl1.MouseUp += openGLControl1_MouseUp;
            openGLControl1.MouseWheel += openGLControl1_MouseWheel;
            openGLControl1.DrawFPS = true;

            _renderTimer = new ();
            _renderTimer.Interval = 15; // Approximately 60 FPS
            _renderTimer.Tick += (s, e) => { openGLControl1.Invalidate(); };
            _renderTimer.Start();

            var color = Color.Green;
            _color = new GLColor(color.R, color.G, color.B, 1f);
            var colorEdge = Color.White;
            _colorEdge = new GLColor(colorEdge.R, colorEdge.G, colorEdge.B, 1f);
        }

        private void btnChangeMode_Click(object sender, EventArgs e)
        {
            _isFilled = !_isFilled;
        }

        private void btnTransparency_Click(object sender, EventArgs e)
        {
            _isTransparent = !_isTransparent;
        }

        private void btnChangeColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
                if (colorDialog.ShowDialog() == DialogResult.OK)
                    _color = colorDialog.Color;
        }

        //UI-methods
        private void DrawCube(OpenGL gl)
        {
            //Грани
            gl.LineWidth(10.0f);
            gl.Begin(OpenGL.GL_LINES); // Начинаем рисовать линии

            // Передние ребра
            gl.Color(_colorEdge); // Черный цвет для ребер
            gl.Vertex(-1, 1, 1);
            gl.Vertex(1, 1, 1);
            gl.Vertex(1, 1, 1);
            gl.Vertex(1, -1, 1);
            gl.Vertex(1, -1, 1);
            gl.Vertex(-1, -1, 1);
            gl.Vertex(-1, -1, 1);
            gl.Vertex(-1, 1, 1);

            // Задние ребра
            gl.Vertex(-1, 1, -1);
            gl.Vertex(1, 1, -1);
            gl.Vertex(1, 1, -1);
            gl.Vertex(1, -1, -1);
            gl.Vertex(1, -1, -1);
            gl.Vertex(-1, -1, -1);
            gl.Vertex(-1, -1, -1);
            gl.Vertex(-1, 1, -1);

            // Соединительные ребра между передними и задними гранями
            gl.Vertex(-1, 1, 1);
            gl.Vertex(-1, 1, -1);
            gl.Vertex(1, 1, 1);
            gl.Vertex(1, 1, -1);
            gl.Vertex(-1, -1, -1);
            gl.Vertex(-1, -1, 1);

            gl.Vertex(1, -1, -1);
            gl.Vertex(1, -1, 1);

            // Завершение рисования линий
            gl.End();

            if (!_isFilled) return;

            //Поерхности
            gl.Begin(OpenGL.GL_QUADS);

            gl.Color(_color); // Красный цвет
            gl.Vertex(-1, -1, 1);
            gl.Vertex(1, -1, 1);
            gl.Vertex(1, 1, 1);
            gl.Vertex(-1, 1, 1);

            // Задняя грань
            gl.Vertex(-1, -1, -1);
            gl.Vertex(-1, 1, -1);
            gl.Vertex(1, 1, -1);
            gl.Vertex(1, -1, -1);

            // Левая грань
            gl.Vertex(-1, -1, -1);
            gl.Vertex(-1, -1, 1);
            gl.Vertex(-1, 1, 1);
            gl.Vertex(-1, 1, -1);

            // Правая грань
            gl.Vertex(1, -1, -1);
            gl.Vertex(1, -1, 1);
            gl.Vertex(1, 1, 1);
            gl.Vertex(1, 1, -1);

            // Верхняя грань
            gl.Vertex(-1, 1, -1);
            gl.Vertex(-1, 1, 1);
            gl.Vertex(1, 1, 1);
            gl.Vertex(1, 1, -1);

            // Нижняя грань
            gl.Vertex(-1, -1, -1);
            gl.Vertex(1, -1, -1);
            gl.Vertex(1, -1, 1);
            gl.Vertex(-1, -1, 1);

            gl.End();
        }

        private void openGLControl1_OpenGLDraw(object sender, RenderEventArgs args)
        {
            var gl = openGLControl1.OpenGL;

            // Очистка буфера
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();

            // Применение трансформаций
            gl.Translate(0.0f, 0.0f, -5.0f);
            gl.Rotate(_angleX, 1.0f, 0.0f, 0.0f);
            gl.Rotate(_angleY, 0.0f, 1.0f, 0.0f);
            gl.Scale(_scale, _scale, _scale);

            // Установка прозрачности
            if (_isTransparent)
            {
                _color = new GLColor(_color.R, _color.G, _color.B, 0.5f);
                _colorEdge = new GLColor(_colorEdge.R, _colorEdge.G, _colorEdge.B, 0.5f);
                gl.Enable(OpenGL.GL_BLEND);
                gl.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE_MINUS_SRC_ALPHA);
            }
            else
            {
                _color = new GLColor(_color.R, _color.G, _color.B, 1f);
                _colorEdge = new GLColor(_colorEdge.R, _colorEdge.G, _colorEdge.B, 1f);
            }

            // Рисование куба
            DrawCube(gl);

            // Обновление экрана
            //openGLControl1.Invalidate();
        }

        private void openGLControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isMouseDown = true;
                _lastMouseX = e.X;
                _lastMouseY = e.Y;
            }
        }

        private void openGLControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isMouseDown)
            {
                float deltaX = e.X - _lastMouseX;
                float deltaY = e.Y - _lastMouseY;

                _angleY += deltaX * 0.5f; // Поворот вокруг Y
                _angleX += deltaY * 0.5f; // Поворот вокруг X

                _lastMouseX = e.X;
                _lastMouseY = e.Y;
            }
        }

        private void openGLControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                _isMouseDown = false;
        }

        private void openGLControl1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                _scale += 0.1f; // Увеличение масштаба
            else if (e.Delta < 0 && _scale > 0.1f) // Ограничение минимального масштаба
                _scale -= 0.1f; // Уменьшение масштаба
        }
    }
}
