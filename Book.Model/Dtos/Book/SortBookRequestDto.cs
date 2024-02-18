namespace Book.Model.Dtos.Book
{
    public class SortBookRequestDto
    {
        /// <summary>
        /// 目標書籍 id
        /// </summary>
        public int SourceId { get; set; }

        /// <summary>
        /// 目標書籍要移動到的目的書籍 id
        /// </summary>
        public int DestinationId { get; set; }
    }
}
