namespace SD_340_W22SD_2021_2022___Final_Project_2.Models.ViewModels
{
    public class CreateCommentViewModel
    {
        public List<Comment> Comments = new List<Comment>();
        public Comment NewComment = new Comment();

        public CreateCommentViewModel(List<Comment> comments, Comment newComment)
        {
            Comments = comments;
            NewComment = newComment;
        }
    }
}
