using System;
using System.Linq;
using System.Windows.Forms;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Repository.Hierarchy;

namespace DemoChangeLog4Net
{
  public partial class FormMain : Form
  {
    private static readonly ILog log = LogManager.GetLogger(typeof(FormMain));

    public FormMain()
    {
      InitializeComponent();
      XmlConfigurator.Configure(); // Charger la configuration de log4net
      InitializeComboBox();
    }

    private void LogStandardToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

    private void LogVerbeuxToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

    private void FormMain_Load(object sender, EventArgs e)
    {

    }

    private void InitializeComboBox()
    {
      comboBoxAppender.Items.Add("userFileAppender");
      comboBoxAppender.Items.Add("developerFileAppender");
      comboBoxAppender.SelectedIndexChanged += ComboBoxAppender_SelectedIndexChanged;
      comboBoxAppender.SelectedIndex = 0;
    }

    private void ComboBoxAppender_SelectedIndexChanged(object sender, EventArgs e)
    {
      var selectedAppenderName = comboBoxAppender.SelectedItem.ToString();
      var hierarchy = (Hierarchy)LogManager.GetRepository();
      hierarchy.Root.RemoveAllAppenders();

      var appender = hierarchy.GetAppenders().FirstOrDefault(a => a.Name == selectedAppenderName);
      if (appender != null)
      {
        hierarchy.Root.AddAppender(appender);
      }

      hierarchy.Configured = true;
      log.Info($"Appender changed to {selectedAppenderName}");
    }

    private void ButtonAddToLog_Click(object sender, EventArgs e)
    {
      log.Info("Button clicked");
    }
  }
}
