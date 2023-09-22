namespace MitsubishiElectric.Widgets.Services.Interfaces
{
    public interface ICanvas
    {
        void AddWidget(Widget widget);
        void Print();
        void Clear();
        public int Widgets { get; }
    }
}