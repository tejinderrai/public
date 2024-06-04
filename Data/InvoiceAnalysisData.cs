namespace BlazorSimpleAI.Data
{
    public class InvoiceAnalysisData
    {
        public string ?VendorName { get; set; }

        public string ?VendorAddress { get; set; }
        public string ?CustomerName { get; set; }

        public string? CustomerAddress { get; set; }

        public List<InvoiceItem> InvoiceItems { get; set; }
        public string ?Tax { get; set; }
        public string ?InvoiceTotal { get; set; }

        
    }
}
