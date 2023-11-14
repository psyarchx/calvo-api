namespace Calvo.CrossCutting.Options
{
    public class ExampleOptionRoot
    {
        public const string Section = "ExampleConfig";

        public ExampleOption Options { get; set; } = default!;

        public class ExampleOption
        {
            public string Client { get; set; } = default!;
            public string Secret { get; set; } = default!;
        }
    }
}
