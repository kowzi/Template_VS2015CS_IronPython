using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronPython.Hosting;
using IronPython.Runtime;
using Microsoft.Scripting.Hosting;


namespace testPython2
{
    public partial class Form1 : Form
    {

        public string FilePathRoot_python = "..\\..\\";     //pythonスクリプトが格納されている相対パス（この.exeファイルを基準)

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //方法１
            //python moduleを使うためのコード
            //引数と戻り値でpython moduleを活用する
            ScriptRuntime py = Python.CreateRuntime();
            dynamic sample = py.UseFile(FilePathRoot_python+"sample.py");
            string result = sample.GetDatePy("FromC#::Method1 ");
            textBox1.Text = result;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //方法２
            //python中の変数に対し直接C#側から変数アクセスする方式
            //pythonの実行結果はpythonの変数に残るので、直接アクセスして取得する
            //http://authorunknown408.blog.fc2.com/blog-entry-36.html (とても参考になりました。ありがとうございます）


            var options = new Dictionary<string, object> ();
            //options["name1"] = true;
            //options["name2"] = true;

            ScriptEngine engine = Python.CreateEngine(options);

            ScriptSource script = engine.CreateScriptSourceFromFile(FilePathRoot_python + "sample2.py");
            ScriptScope scope = engine.CreateScope();

            scope.SetVariable("strFromCS", "FromC#::Method2 ");
            script.Execute(scope);
            textBox1.Text = scope.GetVariable("strReturn");
        }
    }
}
