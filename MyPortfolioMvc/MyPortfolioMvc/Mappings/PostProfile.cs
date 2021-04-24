using AutoMapper;
using MyPortfolioMvc.BLL.DTO.Post;
using MyPortfolioMvc.DAL.Entities;
using MyPortfolioMvc.Models.Post;

namespace MyPortfolioMvc.Mappings
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            // Presentation Layer
            CreateMap<FilterPostDto, PostFilterViewModel>();
            CreateMap<FetchPostDto, PostInfoViewModel>();

            CreateMap<PostCreateViewModel, PostCreateDto>();
            CreateMap<PostUpdateViewModel, PostUpdateDto>();

            // Business Logic Layer
            CreateMap<Post, FilterPostDto>();
            CreateMap<Post, FetchPostDto>();


            CreateMap<PostCreateDto, Post>();
            CreateMap<PostUpdateDto, Post> ();
        }
    }
}
