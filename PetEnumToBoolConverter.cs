using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace RadioButtonSample
{
    //*********************************************************************************
    /// <summary>ペット列挙体コンバータークラス</summary>
    /// <Note>
    /// Bindingで使用するコンバーターです。
    /// コンバーターパラメーターを指定する必要があります。
    /// </Note>
    /// <Remarks>
    /// 参考：http://frog.raindrop.jp/knowledge/archives/002200.html
    /// </Remarks>
    //*********************************************************************************
    public class PetEnumToBoolConverter : IValueConverter
    {
        /// <summary>EnumとBoolへの変換</summary>
        /// <param name="value">BindingソースのEnum型オブジェクト</param>
        /// <param name="targetType">Bindingターゲットの型</param>
        /// <param name="parameter">パラメーター（Enum要素の文字列）</param>
        /// <param name="culture">カルチャー</param>
        /// <returns>Bool値</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // バインドする列挙値の文字列表記がパラメータに渡されているか
            var strEnum = parameter as string;
            if (strEnum == null)
            {
                // 本当は実装ミスなので例外とする
                return DependencyProperty.UnsetValue;
            }
            // パラメータがEnumの値として正しいか
            if (!Enum.IsDefined(value.GetType(), strEnum))
            {
                return DependencyProperty.UnsetValue;
            }

            // パラメータをEnum要素に変換し、Bindingソースと一致した場合はtrueを返す
            return (value.Equals(Enum.Parse(value.GetType(), strEnum)));
        }

        /// <summary>BoolからEnumへの変換</summary>
        /// <param name="value">BindingターゲットのBool型オブジェクト</param>
        /// <param name="targetType">Bindingソースの型</param>
        /// <param name="parameter">パラメーター（Enum要素の文字列）</param>
        /// <param name="culture">カルチャー</param>
        /// <returns>Enum値</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // バインドする列挙値の文字列表記がパラメータに渡されているか
            var strEnum = parameter as string;
            if (strEnum == null)
            {
                // 本当は実装ミスなので例外とする
                return DependencyProperty.UnsetValue;
            }

            // チェックが入っている場合パラメーターを列挙型にパースして返す
            var isChecked = (bool)value;
            return isChecked ? Enum.Parse(targetType, strEnum) : DependencyProperty.UnsetValue;
        }
    }
}
