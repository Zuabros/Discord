// MÓDULO 01 - IMPORTAÇÕES
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices; // Required for Windows API functions
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Discord
{
 public partial class Form1 : Form
 {
	// MÓDULO 02 - VARIÁVEIS GLOBAIS

	// DLL Imports
	[DllImport("user32.dll")]
	private static extern bool SetForegroundWindow(IntPtr hWnd);

	[DllImport("user32.dll")]
	private static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

	[DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
	private static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

	// M20 - Variaveis de estado de jogo e personagem
	bool enroscou = false; // Variável global para controlar estado de enrosco
	int res_x; // resoluçao x do jogo  
	int res_y; // resolução y do jogo 

	// Constantes de mouse e teclado
	public const int MOUSEEVENTF_LEFTDOWN = 0x02;
	public const int MOUSEEVENTF_LEFTUP = 0x04;
	public const int MOUSEEVENTF_RIGHTDOWN = 0x08;
	public const int MOUSEEVENTF_RIGHTUP = 0x10;
	public const int KEYEVENTF_EXTENDEDKEY = 0x0001;
	public const int KEYEVENTF_KEYUP = 0x0002;

	// Teclas
	public const int AKEY = 0x41;
	public const int DKEY = 0x44;
	public const int QKEY = 0x51;
	public const int WKEY = 0x57;
	public const int EKEY = 0x45;
	public const int SKEY = 0x53;
	public const int SPACEBAR = 0x20;
	public const int UM = 0x31;
	public const int DOIS = 0x32;
	public const int TRES = 0x33;
	public const int QUATRO = 0x34;
	public const int CINCO = 0x35;
	public const int SEIS = 0x36;
	public const int SETE = 0x37;
	public const int OITO = 0x38;
	public const int NOVE = 0x39;
	public const int ZERO = 0x30;
	public const int N1 = 0x61;
	public const int N2 = 0x62;
	public const int N3 = 0x63;
	public const int N4 = 0x64;
	public const int N5 = 0x65;
	public const int N6 = 0x66;
	public const int N7 = 0x67;
	public const int N8 = 0x68;
	public const int N9 = 0x69;
	public const int N0 = 0x60;

	// Variáveis de posição (calculadas dinamicamente depois)
	public static loc hp;      // Centro do quadradinho de HP
	public static loc mana;    // Centro do quadradinho de Mana
	public static loc X;       // Centro do quadradinho de posição X
	public static loc y;       // Centro do quadradinho de posição Y
	public static loc yaw_spd; // Centro do quadradinho de Yaw/Speed

	// M10 - STRUCT LOC - REPRESENTA UMA POSIÇÃO (X, Y) NA ESCALA MULTIPLICADA POR 10.
	public struct loc
	{
	 public int x;
	 public int y;

	 public loc(int x, int y)
	 {
		this.x = x;
		this.y = y;
	 }
	}

	// MÓDULO 12 - STRUCT ELEMENT - REPRESENTA QUALQUER ENTIDADE (PLAYER, MOB, NPC) NO MAPA.
	public struct element
	{
	 public loc pos;      // Posição atual
	 public bool combat;  // Está em combate
	 public int hp;       // Vida (em % ou escalado)
	 public int mana;     // Mana (em % ou escalado)
	 public bool hostile; // Se é hostil
	 public int level;    // Nível do elemento
	 public int type;     // Tipo (1 = Player, 2 = Mob, etc.)
	 public double facing;

	 public element(loc pos, bool combat, int hp, int mana, bool hostile, int level, int type, double facing)
	 {
		this.pos = pos;
		this.combat = false;
		this.hp = hp;
		this.mana = mana;
		this.hostile = hostile;
		this.level = level;
		this.type = type;
		this.facing = facing;
	 }
	}

	// Construtor
	public Form1()
	{
	 InitializeComponent();
	 
	 inicializa();
	 
	}
	// M21 - INICIALIZA VARIÁVEIS DINÂMICAS INICIAIS
	private void inicializa()
	{
	 if (cb_12801024.Checked)
	 {
		res_x = 1280;
		res_y = 1024;
	 }
			else if (cb_1366768.Checked)
			{
				res_x = 1366;
				res_y = 768;

            }

				int left_mrg = (int)(res_x * 0.02);  // 2% da largura
	 int top = (int)(res_y * 0.15);       // 15% da altura
	 int tam_quad = 16;                   // Tamanho do quadrado
	 int gap_h = 2;                       // Gap horizontal entre quadrados
	 int gap_v = 10;                      // Gap vertical entre linhas
	 int top2 = top + tam_quad + gap_v;   // Topo da segunda linha

	 // Primeira linha
	 hp = new loc(left_mrg + (tam_quad / 2), top + (tam_quad / 2));
	 mana = new loc(left_mrg + (tam_quad + gap_h) + (tam_quad / 2), top + (tam_quad / 2));

	 // Segunda linha
	 X = new loc(left_mrg + (tam_quad / 2), top2 + (tam_quad / 2));
	 y = new loc(left_mrg + (tam_quad + gap_h) + (tam_quad / 2), top2 + (tam_quad / 2));
	 yaw_spd = new loc(left_mrg + (2 * (tam_quad + gap_h)) + (tam_quad / 2), top2 + (tam_quad / 2));

		}



	private void tb_mana_TextChanged(object sender, EventArgs e)
	{

	}

	// M03 - MÉTODO WAIT - ESPERA SEM TRAVAR A JANELA.
	public void wait(int milliseconds)
	{
	 System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
	 while (sw.ElapsedMilliseconds <= milliseconds)
	 {
		Application.DoEvents();
	 }
	}

	// M04 - MÉTODO FOCAR WOW - TRAZ A JANELA DO WOW PARA FRENTE.
	public void focawow()
	{
	 var prc = Process.GetProcessesByName("WowClassic");
	 if (prc.Length > 0)
	 {
		SetForegroundWindow(prc[0].MainWindowHandle);
	 }
	 else
		MessageBox.Show("Wow window not found");
	}

	// M05 - MÉTODO APERTA - ENVIA UM PRESSIONAMENTO DE TECLA PARA O WOW.
	public void aperta(byte key, int time = 50) // time 0 = pressiona, time 2 = solta
	{
	 focawow(); // Foca a janela do WoW
	 if (time != 2) keybd_event(key, 0, KEYEVENTF_EXTENDEDKEY, 0); // Pressiona
	 if (time != 2) wait(time); // Espera
	 if (time > 0) keybd_event(key, 0, KEYEVENTF_KEYUP, 0); // Solta
	}

	// M06 - MÉTODO MOUSEMOVE - MOVE O CURSOR PARA A POSIÇÃO (X, Y).
	public void mousemove(int x, int y)
	{
	 Cursor.Position = new Point(x, y);
	}

	// M07 - MÉTODO DOMOUSECLICK - REALIZA UM CLIQUE DO MOUSE.
	public void DoMouseClick(int botao = 1)
	{
	 int X = Cursor.Position.X;
	 int Y = Cursor.Position.Y;
	 if (botao == 1)
		mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
	 else if (botao == 2)
		mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, X, Y, 0, 0);
	}

	// M01 - MÉTODO CLICA - MOVE O MOUSE PARA (X, Y) E REALIZA UM CLIQUE COM O BOTÃO INFORMADO.
	public void clica(int x, int y, int botao = 1)
	{
	 mousemove(x, y);
	 DoMouseClick(botao);
	}

	// M02 - MÉTODO GETCOLORAT - CAPTURA A COR DO PIXEL NA COORDENADA (X, Y).
	public Color GetColorAt(int x, int y)
	{
	 using (Bitmap bmp = new Bitmap(1, 1))
	 {
		using (Graphics g = Graphics.FromImage(bmp))
		{
		 g.CopyFromScreen(x, y, 0, 0, new Size(1, 1));
		}
		return bmp.GetPixel(0, 0);
	 }
	}

	// M08 - MÉTODO GETANGLE - CALCULA O ÂNGULO ENTRE DOIS PONTOS, NORMALIZADO DE 0 A 2000ms.
	public double getangle(double y1, double y2, double x1, double x2) // esta trocado pois Y cresce para baixo no WOW
	{
	 double ang = Math.Atan2(x1 - x2, y1 - y2) / Math.PI;
	 if (ang < 0)
		ang += 2;
	 return Math.Round(ang * 1000);
	}

	// M09 - MÉTODO GETYAW - CALCULA O ÂNGULO DE ROTAÇÃO NECESSÁRIO ENTRE UM PONTO DE ORIGEM E UM ALVO, BASEADO NO FACING ATUAL.
	public double getyaw(loc orig, loc tar, double facing)
	{
	 double pitch = getangle(orig.y, tar.y, orig.x, tar.x); // Esse método usa módulo (%) para fazer a volta no círculo automaticamente:
	 double yaw_result = (pitch - facing + 2000) % 2000;
	 return yaw_result;
	}

	// MÉTODO GIRALVO - GIRA PARA UM ALVO. 
	public void giralvo(loc alvo)
	{
	 getstats(ref player); // Atualiza posição e facing do player

	 // 1. Calcula o ângulo de destino (pitch) e a diferença de ângulo (yaw)
	 double angulo_destino = getangle(player.pos.y, alvo.y, player.pos.x, alvo.x); // Ângulo para o alvo
	 double yaw = angulo_destino - player.facing; // Diferença entre onde está olhando e o alvo

	 // 2. Normaliza yaw para ficar entre -1000 e 1000
	 if (yaw > 1000) yaw -= 2000;
	 if (yaw < -1000) yaw += 2000;

	 // 3. Calcula quantos milissegundos apertar
	 // Sabendo que 1000ms = 180° (π rad)
	 int tempo_ms = (int)Math.Round(Math.Abs(yaw) * (1000.0 / 1000.0)); // yaw em milissegundos (1 radiano ≈ 572ms)
	 if (tempo_ms > 200) aperta(SPACEBAR); // se vai girar muito, dá um pulinho
	 // 4. Pressiona AKEY ou DKEY dependendo do lado que tem que virar
	 if (yaw > 0)
		aperta(AKEY, tempo_ms); // Gira para esquerda
	 else if (yaw < 0)
		aperta(DKEY, tempo_ms); // Gira para direita
	 else
		; // Já está alinhado, não faz nada
	}

		// M11 - MÉTODO DIST - CALCULA A DISTÂNCIA ENTRE DUAS COORDENADAS (LOC).
	public int dist(loc orig, loc tar)
	{
	 double distance = Math.Sqrt(Math.Pow(Math.Abs(orig.x - tar.x), 2) +
															 Math.Pow(Math.Abs(orig.y - tar.y), 2));
	 return (int)distance;
	}

	// MÓDULO 13 - MÉTODO COMBATLOOP - ROTINA DE COMBATE (ESQUELETO, AINDA NÃO IMPLEMENTADO).
	public void combatloop()
	{
	 // TODO: Implementar rotina de combate
	 return;
	}

	// M16 - MÉTODO GETSTATS - CAPTURA STATUS DO PERSONAGEM
	public void getstats(ref element e)
	{
	 focawow(); // Foca a janela do WoW para capturar pixels corretos

	 // HP
	 Color c_hp = GetColorAt(hp.x, hp.y); // Lê a cor no quadrado de HP
	 int v_hp = (c_hp.G * 100) / 255; // Normaliza o canal verde (0-255) para porcentagem (0-100)
	 e.hp = v_hp; // Atualiza o HP no objeto player
	 tb_hp.Text = v_hp.ToString(); // Atualiza o TextBox de HP

	 // Mana
	 Color c_mana = GetColorAt(mana.x, mana.y); // Lê a cor no quadrado de Mana
	 int v_mana = (c_mana.B * 100) / 255; // Normaliza o canal azul (0-255) para porcentagem (0-100)
	 e.mana = v_mana; // Atualiza o Mana no objeto player
	 tb_mana.Text = v_mana.ToString(); // Atualiza o TextBox de Mana

	 // X
	 Color c_x = GetColorAt(X.x, X.y); // Lê a cor no quadrado de X
	 int int_x = (int)Math.Floor(c_x.R / 2.8); // Parte inteira do X (canal vermelho)
	 int dec_x = (int)Math.Floor(c_x.G / 2.8); // Parte decimal do X (canal verde)
	 int final_x = (int_x * 100) + dec_x; // Combina inteiro e decimal
	 e.pos.x = final_x; // Atualiza a posição X do player
	 tb_x.Text = final_x.ToString(); // <-- Mostra o valor bruto no TextBox (sem conversão)

	 // Y
	 Color c_y = GetColorAt(y.x, y.y); // Lê a cor no quadrado de Y
	 int int_y = (int)Math.Floor(c_y.R / 2.8); // Parte inteira do Y (canal vermelho)
	 int dec_y = (int)Math.Floor(c_y.G / 2.8); // Parte decimal do Y (canal verde)
	 int final_y = (int_y * 100) + dec_y; // Combina inteiro e decimal
	 e.pos.y = final_y; // Atualiza a posição Y do player
	 tb_y.Text = final_y.ToString(); // <-- Mostra o valor bruto no TextBox também


	 // Facing (Yaw)
	 Color c_yawspd = GetColorAt(yaw_spd.x, yaw_spd.y); // Lê a cor no quadrado de Yaw/Speed
	 double yaw_raw = (c_yawspd.R * 1.0) / 255.0; // Normaliza yaw do canal vermelho para 0-1
	 double yaw = yaw_raw * 2000; // Converte yaw para escala interna (0-2000)
	 player.facing = Math.Round(yaw); // Atualiza o facing global
	 tb_yaw.Text = player.facing.ToString(); // Atualiza o TextBox de yaw

	 // Speed
	 double spd_raw = (c_yawspd.G * 1.0) / 255.0; // normaliza para 0-1
	 double spd_corrida = spd_raw * 255.0; // escala de volta para 0-255
	 int spd = (int)Math.Round((spd_corrida * 100.0) / 105.0); // normaliza 105 = 100%
	 tb_spd.Text = spd.ToString();
	}





	// M17 - MÉTODO UNSTUCK - TENTA DESBLOQUEAR O PERSONAGEM COM SALTO E GIRO ALTERNADO.


	public void unstuck()
	{
	 focawow(); // Foca a janela do WoW

	 if (!enroscou)
	 {
		aperta(SPACEBAR, 100); // Primeira tentativa: pular
	 }
	 else
	 {
		aperta(WKEY); // Começa a andar
		aperta(EKEY, 700); // Vira para sudeste (você usava E, adaptável depois)
		aperta(WKEY, 1000); // Anda um pouco depois de virar
	 }

	 aperta(WKEY, 0); // Continua andando sem parar
	 enroscou = !enroscou; // Alterna o estado para próxima tentativa
	}

	// MÓDULO 18 - VARIÁVEL GLOBAL - OBJETO PLAYER
	public element player;


	 // MÓDULO 14 - MÉTODO MOVETO - MOVE O PERSONAGEM ATÉ O DESTINO INFORMADO
	 public void moveto(loc destino)
	 {
		
		 getstats(ref player); // Lê posição e facing iniciais
		 int temp = 0; // Contador de ciclos
		 
			do
			{
			temp++;
			getstats(ref player); // Atualiza posição e facing
			int distance = dist(player.pos, destino); // Calcula distância
      tb_debug3.Text=distance.ToString();
			if (temp % 6 == 0) aperta(SPACEBAR);
			tb_debug4.Text=temp.ToString();
			 aperta(WKEY, 0); // Pressiona W
       int wait_time = 300;
			 wait(wait_time); // Aguarda 500ms
				
		giralvo(destino);
		}
		 while (dist(player.pos, destino) > 10);
	 aperta(WKEY, 2); // Solta W	
	}
		
		
	 


	

	// M19 - MÉTODO GIRAMS - GIRA O PERSONAGEM POR UM TEMPO EM MILISSEGUNDOS
	public void girams(double ms)
	{
	 if (ms <= 30 || ms > 1970) return; // Tolerância mínima para considerar que precisa girar

	 if (ms < 1000)
	 		aperta(AKEY, (int)ms); // Se menor que 1000ms, gira para a esquerda (A)
	 else // mais que 180 graus de giro, vira para direita. 
			{
		double ms_corrigido = 2000 - ms; // Corrige para girar para a direita (D)
		aperta(DKEY, (int)ms_corrigido); // Gira para a direita pelo tempo corrigido
			}
	 // Se dentro da tolerância (0-30ms), não gira
	 
	}

	private void bt_getstats_Click(object sender, EventArgs e)
	{
	 getstats(ref player); // Chama o método getstats para atualizar o objeto player
	}

	//BOTÃO DEBUG1 - MOVE PARA DESTINO DAS TEXTBOXES
private void bt_debug1_Click(object sender, EventArgs e)
	{
	 try
	 {
		getstats(ref player);
		int x = int.Parse(tb_debug1.Text); // X alvo (ex.: 481, já em escala x10)
		int y = int.Parse(tb_debug2.Text); // Y alvo (ex.: 421, já em escala x10)
		loc destino = new loc(x, y); // Destino (481,421)
		moveto(destino);
	 }
	 catch (Exception ex)
	 {
		tb_debug3.Text = "Erro no destino: " + ex.Message; // Exibe erro na UI
	 }
	}

	private void bt_debug2_Click(object sender, EventArgs e)
	{
	 getstats(ref player);
	 tb_debug1.Text = player.pos.x.ToString();
	 tb_debug2.Text = player.pos.y.ToString();

	}
	// BOTAO GIRALVO, LE COORDENADAS DAS TB E GIRA PARA ELAS. 
	private void bt_debug3_Click(object sender, EventArgs e)
	{
	 // 1. Lê as coordenadas dos TextBoxes
	 int alvo_x = int.Parse(tb_debug1.Text);
	 int alvo_y = int.Parse(tb_debug2.Text);

	 // 2. Cria o loc alvo
	 loc alvo = new loc(alvo_x, alvo_y);

	 // 3. Chama a função giralvo passando o loc alvo
	 giralvo(alvo);
	}



	// FIM DOS METODOS GLOBAIS 
 }
}
