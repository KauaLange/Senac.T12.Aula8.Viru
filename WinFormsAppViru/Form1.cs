using System.Runtime.InteropServices;

namespace WinFormsAppViru
{
    public partial class Form1 : Form
    {
        // variáveis
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;
        // metodo que executa o evento de click
        [DllImport("user32.dll",
            CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall)
        ]
        public static extern void mouse_event(int dwFlags,
            int dx,
            int dy,
            int cButtons,
            int dwExtraInfo);
        // gerar as posições aleatorias

        private Random random = new Random();

        // Movimento aleatorio do mouse

        private void MoverCursor()
        {
            // Largura da tela
            int larguraTela = Screen.PrimaryScreen.Bounds.Width;
            // Altura da tela
            int alturaTela = Screen.PrimaryScreen.Bounds.Width;
            // posiçãoXAleatoria
            int posicaoXAleatoria = random.Next(larguraTela);
            // posiçãoYAleatoria
            int posicaoYAleatoria = random.Next(alturaTela);
            //Posição do Cursor
            Cursor.Position = new Point(posicaoXAleatoria, posicaoYAleatoria);
        }
        public Form1()
        {
            InitializeComponent();
        }

        // no evento de click
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                // chamando o metodo que move o mouse
                MoverCursor();

                for (int tico = 1; tico <= 2; tico++)

                    MouseClicar();

                // Cerebro. Dormir 1 segundo
                Thread.Sleep(100);
            }
            
            
        }

        private void MouseClicar()
        {
            mouse_event(
                MOUSEEVENTF_LEFTDOWN, // código de evento de pressionar
                Cursor.Position.X, // posição x do cursor
                Cursor.Position.Y, 0, 0); // posição y do cursor
            //executa o soltar o botão esquerdo do mouse
            mouse_event(
                MOUSEEVENTF_LEFTUP, // codigo do evento de soltar o botão
                Cursor.Position.X, // posição x do cursor
                Cursor.Position.Y, 0, 0); // posição y do cursor


        }
    }
}
