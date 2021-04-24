using MyPortfolioMvc.BLL.DTO.Post;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyPortfolioMvc.BLL.Interfaces
{
    public interface IPostService
    {
        void CreatePost(PostCreateDto postCreateDto);

        void UpdatePost(PostUpdateDto postCreateDto);

        void DeletePost(int id);

        FetchPostDto GetPost(int? id);

        (IEnumerable<FilterPostDto>, IEnumerable<string>) GetFilterPosts(string postCreateDate, string searchString);

        void Dispose();
    }
}
