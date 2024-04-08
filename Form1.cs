using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace LAB8
{
    public partial class Form1 : Form
    {
        List<int> notasTemp = new List<int>();
        List<NotasAlumno> listaNotas = new List<NotasAlumno>();

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        

    private void button1_Click(object sender, EventArgs e)
        {
            
            int nota = Convert.ToInt32(textBox2.Text);
            notasTemp.Add(nota);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Guarda a un alumno con sus notas
            NotasAlumno notasAlumno = new NotasAlumno();

            notasAlumno.Nombre = textBox1.Text;
            notasAlumno.Notas = notasTemp.GetRange(0, notasTemp.Count);
            //Guarda a ese alumo en el listado de notas
            listaNotas.Add(notasAlumno);
            //Borra las notas temporales para el proximo alumno
            Grabar();
            notasTemp.Clear();
            
        }
        private void Grabar()
        {
            string json = JsonConvert.SerializeObject(listaNotas);
            string archivo = "Datos.json";
            System.IO.File.WriteAllText(archivo, json);
        }
    }
}
