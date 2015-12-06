using System;
using System.Windows.Input;

namespace RadioButtonSample
{
    //*********************************************************************************
    /// <summary>
    /// ペット変更コマンド
    /// </summary>
    //*********************************************************************************
    public class ChangePetCommand : ICommand
    {
        /// <summary>
        /// CanExecute変更イベントのデリゲート
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// コマンドの実行
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
        }

        /// <summary>
        /// コマンドの実行可否
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
