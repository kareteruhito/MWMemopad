using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace MWMemopad;

public partial class MainWindow : Window
{
    private string? currentFile;

    public MainWindow()
    {
        InitializeComponent();
    }
    // 新規作成
    private void New_Click(object sender, RoutedEventArgs e)
    {
        Editor.Clear();
        currentFile = null;
        Title = "メモ帳";
    }
    // 開く
    private void Open_Click(object sender, RoutedEventArgs e)
    {
        var dialog = new OpenFileDialog
        {
            Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
        };

        if (dialog.ShowDialog() == true)
        {
            currentFile = dialog.FileName;
            Editor.Text = File.ReadAllText(currentFile);
            Title = $"メモ帳 - {Path.GetFileName(currentFile)}";
        }
    }
    // 保存
    private void Save_Click(object sender, RoutedEventArgs e)
    {
        if (currentFile == null)
        {
            var dialog = new SaveFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
            };

            if (dialog.ShowDialog() != true)
                return;

            currentFile = dialog.FileName;
        }

        File.WriteAllText(currentFile, Editor.Text);
        Title = $"ScratchPad - {Path.GetFileName(currentFile)}";
    }
    // 終了
    private void Exit_Click(object sender, RoutedEventArgs e)
    {
        // アプリケーションを終了させる標準的なコード
        Application.Current.Shutdown();
    }
}