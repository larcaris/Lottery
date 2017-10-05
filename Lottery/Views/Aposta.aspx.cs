using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lottery
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /*Generate 60 checkbox in Checkboxlist1*/
                for (int i = 1; i <= 60; i++)
                {
                    CheckBoxList1.Items.Add(new ListItem(i.ToString()));
                }

                /*Set the checkboxlist properties*/
                CheckBoxList1.CellPadding = 5;
                CheckBoxList1.CellSpacing = 5;
                CheckBoxList1.RepeatColumns = 6;
                CheckBoxList1.RepeatDirection = RepeatDirection.Vertical;
                CheckBoxList1.RepeatLayout = RepeatLayout.Flow;
                CheckBoxList1.TextAlign = TextAlign.Right;

            }
        }

        /*Method that generate random list of size 6, with interval from 1 to 60.*/
        public List<int> GerarRandom()
        {
            List<int> listaRand = new List<int>();
            for (int i = 0; i < 6; i++)
            {
                Random r = new Random();
                int FuncRandom = r.Next(1, 60);

                /*Goes generate random number until to find some number that is not included in 'listaRand'*/
                while (listaRand.Contains(FuncRandom))
                {
                    FuncRandom = r.Next(1, 60);
                }

                listaRand.Add(FuncRandom);
            }
            return listaRand;
        }

        /*Method that generate bet and include the numbers in a list 'numerosSelecionados'*/
        protected void btnIncluirAposta_Click(object sender, EventArgs e)
        {
            int contador = 0;
            List<int> numerosSelecionados = new List<int>();

            if (CheckBoxList1 != null)
            {
                for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                {
                    if (CheckBoxList1.Items[i].Selected)
                    {
                        numerosSelecionados.Add(Convert.ToInt32(CheckBoxList1.Items[i].Text));
                        contador++;
                    }
                }
            }

            /*Creating list with the 'MegaSena' properties*/
            List<MegaSena> listaMegasena = new List<MegaSena>();

            /*Here, is verified if the selected numbers quantity is equal the 6.*/
            if (contador == 6)
            {
                /*If the session 'JogoSalvo' is different of null, that is, there's a bet added.*/
                /*Then the 'listaMegaSena' get the bet that is already added.*/
                if (Session["JogoSalvo"] != null)
                {
                    listaMegasena = (List<MegaSena>)Session["JogoSalvo"];
                }

                /*Create a instantiate of 'MegaSena' class*/
                MegaSena mega = new MegaSena();
                mega.NumAposta = Guid.NewGuid().ToString();
                mega.NumSelecionados = numerosSelecionados;
                mega.Data = DateTime.Now;

                /*Now, added the bet done with all features of 'MegaSena' class at 'listaMegasena'*/
                listaMegasena.Add(mega);

                /*Added tha updated list on the session*/
                Session["JogoSalvo"] = listaMegasena;

                CarregarGrid();

                CheckBoxList1.ClearSelection();
            }
            /*User tried add a bet with more ou less numbers, occurring the error in else:*/
            else
            {
                message.Text = "A quantidade de números selecionados devem ser igual a 6!";
                CheckBoxList1.ClearSelection();
            }
        }

        /*In this method, is generate a 'Surpresinha' bet. This bet is generate random by system.*/
        protected void btnGerarSurpresinha_Click(object sender, EventArgs e)
        {
            List<MegaSena> listaMega = new List<MegaSena>();
            List<int> listaInt = GerarRandom();

            if (Session["JogoSalvo"] != null)
            {
                listaMega = (List<MegaSena>)Session["JogoSalvo"];
            }

            MegaSena mega = new MegaSena();
            mega.NumAposta = Guid.NewGuid().ToString();
            mega.NumSelecionados = listaInt;
            mega.Data = DateTime.Now;

            listaMega.Add(mega);

            Session["JogoSalvo"] = listaMega;

            CarregarGrid();
        }

        /*This method will display the numbers, the id, the date and hour and the successful results. */
        public void CarregarGrid()
        {
            List<MegaSena> listaJogos = new List<MegaSena>();
            listaJogos = (List<MegaSena>)Session["JogoSalvo"];

            GridView1.DataSource = listaJogos;
            GridView1.DataBind();
        }

        /*This method will to display the data of the bet*/
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                MegaSena Row = (MegaSena)e.Row.DataItem;
                e.Row.Cells[1].Text = string.Join(" , ", Row.NumSelecionados.ToArray());

                if (Row.Resultado == null)
                {
                    e.Row.Cells[3].Visible = false;
                    GridView1.HeaderRow.Cells[3].Visible = false;
                }
            }
        }

        /*This method will drawn the 6 numbers of lottery.*/
        protected void btnSortear_Click(object sender, EventArgs e)
        {
            /*Is checked if some bet has done.*/
            if (Session["JogoSalvo"] != null)
            {
                /*Number drawn*/
                List<int> numeroSorteado = GerarRandom();

                /*Show the 'numeroSorteado' at display*/
                lblNumeroSorteado.Text = "Jogo Sorteado: " + string.Join("     ", numeroSorteado.ToArray());

                /*Generated numbers list*/
                List<MegaSena> ListadeJogos = (List<MegaSena>)Session["JogoSalvo"];

                foreach (MegaSena megasena in ListadeJogos)
                {
                    /*Load the bet numbers */
                    List<int> NumerosSelecionado = megasena.NumSelecionados;

                    /*Is done the intersection between the generated numbers list and the choosed numbers to verify the number of hits.*/
                    var acertos = numeroSorteado.Intersect(NumerosSelecionado).ToList();

                    /*Fill the result field.*/
                    megasena.Resultado = acertos.Count.ToString();
                }

                Session["JogoSalvo"] = ListadeJogos;
                CarregarGrid();
            }
            else
            {
                message.Text = "Para fazer o sorteio, é necessário fazer pelo menos um jogo.";
            }
        }
        /*This method clear all fields and the session too.*/
        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            Session["JogoSalvo"] = null;
            Response.Redirect("Aposta.aspx");
        }

    }
}