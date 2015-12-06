using System.Windows;

namespace RadioButtonSample
{
    //*********************************************************************************
    /// <summary>
    /// ビューモデルクラス
    /// </summary>
    //*********************************************************************************
    class ViewModel : DependencyObject
    {
        //=============================================================================
        // 構造体・列挙体
        //=============================================================================

        /// <summary>
        /// ペットの列挙体
        /// </summary>
        public enum PetEnum
        {
            Dog, Cat, Hamster
        }

        //=============================================================================
        // 依存関係プロパティ
        //=============================================================================

        /// <summary>ペットの依存関係プロパティ</summary>
        public static readonly DependencyProperty PetProperty =
            DependencyProperty.Register("Pet",
                                typeof(PetEnum),
                                typeof(ViewModel),
                                new FrameworkPropertyMetadata(PetEnum.Dog));

        /// <summary>ペットのCLRプロパティ</summary>
        public PetEnum Pet
        {
            get { return (PetEnum)GetValue(PetProperty); }
            set { SetValue(PetProperty, value); }
        }
    }
}
