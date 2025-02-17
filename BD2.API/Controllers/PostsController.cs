﻿using AutoMapper;
using BD2.API.Configuration;
using BD2.API.Database.Entities;
using BD2.API.Database.Repositories.Interfaces;
using BD2.API.Models.Auth;
using BD2.API.Models.Posts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BD2.API.Controllers
{
    [Route("api/[controller]")]
    public class PostsController : ExtendedControllerBase
    {
        private readonly IPostsRepository _repo;
        private readonly IImagesRepository _irepo;
        private readonly IMapper _mapper;

        public PostsController(IPostsRepository repo, IMapper mapper, IImagesRepository irepo)
        {
            _repo = repo;
            _mapper = mapper;
            _irepo = irepo;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var post = await _repo.FindAsync(id);

            if (post == null)
            {
                return NotFound(new
                {
                    Success = false,
                    Errors = new List<string> { "Nie znaleziono postu o podanym Id" }
                });
            }

            var postModel = new
            {

                Post = post,
                Images = post.Images.Select(x => x.ImageId),
                Owner = _mapper.Map<UserModel>(post.Owner),
                Group = post.Group,
                IsOwner = post.Owner != null && post.Owner.Email == UserEmail,
                Comments = post.Comments.Select(y => new PostCommentModel()
                {
                    Text = y.Text,
                    CommentDate = y.CommentDate,
                    Account = _mapper.Map<UserModel>(y.Account)
                }),
                Reaction = post.Reactions.Select(y => new PostReactionModel()
                {
                    Type = y.Type,
                    ReactionDate = y.ReactionDate,
                    Account = _mapper.Map<UserModel>(y.Account)
                }),
                Views = post.Views.Select(y => new PostViewModel()
                {
                    ViewDate = y.ViewDate,
                    Account = _mapper.Map<UserModel>(y.Account)
                }),
                HasReacted = post.Reactions.Where(x => x.AccountId == UserId).Select(x => x.Type).FirstOrDefault(),
                HasNotifiedAbusement = post.Abusements.Any(x => x.AccountId == UserId),
            };

            return Ok(new
            {
                Model = postModel,
                Success = true,
            });
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetForModerator()
        {
            if (!User.IsInRole(AppRole.MODERATOR.ToString()))
            {
                return Unauthorized(new
                {
                    Success = false,
                    Errors = new List<string>()
                    {
                        "Użytkownik nie ma uprawnienień do moderacji postów",
                    }
                });
            }

            var posts = await _repo.All().ToListAsync();

            if (posts == null)
            {
                return NotFound(new
                {
                    Success = false,
                    Errors = new List<string> { "Nie znaleziono postów" }
                });
            }

            return Ok(new
            {
                Model = posts,
                Success = true,
            });
        }

        [HttpGet]
        [Route("list/user/{id}")]
        public async Task<IActionResult> UserPosts(Guid id)
        {
            var posts = await _repo.FindUserPosts(id, UserId);

            if (posts == null)
            {
                return NotFound(new
                {
                    Success = false,
                    Errors = new List<string> { $"Nie znaleziono postów użytkownika o id = {UserId}" }
                });
            }

            var postsModel = posts.Select(x => new
            {
                Post = x,
                Images = x.Images.Select(x => x.ImageId),
                Owner = _mapper.Map<UserModel>(x.Owner),
                IsOwner = x.Owner != null && x.Owner.Email == UserEmail,
                HasReacted = x.Reactions.Where(x => x.AccountId == UserId).Select(x => x.Type).FirstOrDefault(),
                Group = x.Group,
                HasNotifiedAbusement = x.Abusements.Any(x => x.AccountId == UserId),
            });

            return Ok(new
            {
                Model = postsModel,
                Success = true,
            });
        }

        [HttpGet]
        [Route("list/group/{id}")]
        public async Task<IActionResult> GroupPosts(Guid id)
        {
            var posts = await _repo.FindGroupPosts(id, UserId);

            if (posts == null)
            {
                return NotFound(new
                {
                    Success = false,
                    Errors = new List<string> { $"Nie znaleziono postów użytkownika o id = {UserId}" }
                });
            }

            var postsModel = posts.Select(x => new
            {
                Post = x,
                Images = x.Images.Select(x => x.ImageId),
                Owner = _mapper.Map<UserModel>(x.Owner),
                IsOwner = x.Owner != null && x.Owner.Email == UserEmail,
                HasReacted = x.Reactions.Where(x => x.AccountId == UserId).Select(x => x.Type).FirstOrDefault(),
                Group = x.Group,
                HasNotifiedAbusement = x.Abusements.Any(x => x.AccountId == UserId),
            });

            return Ok(new
            {
                Model = postsModel,
                Success = true,
            });
        }

        [HttpGet]
        [Route("list/friends")]
        public async Task<IActionResult> FriendsPosts()
        {
            if (UserId == null)
            {
                return Unauthorized(new
                {
                    Success = false,
                    Errors = new List<string> { "Błąd uwierzytelniania, zaloguj się ponownie i spróbuj jeszcze raz" }
                });
            }

            var posts = await _repo.FindFriendsPosts((Guid)UserId);

            if (posts == null)
            {
                return NotFound(new
                {
                    Success = false,
                    Errors = new List<string> { $"Nie znaleziono postów użytkownika o id = {UserId}" }
                });
            }

            var postsModel = posts.Select(x => new
            {
                Post = x,
                Images = x.Images.Select(x => x.ImageId),
                Owner = _mapper.Map<UserModel>(x.Owner),
                IsOwner = x.Owner != null && x.Owner.Email == UserEmail,
                HasReacted = x.Reactions.Where(x => x.AccountId == UserId).Select(x => x.Type).FirstOrDefault(),
                Group = x.Group,
                HasNotifiedAbusement = x.Abusements.Any(x => x.AccountId == UserId),
            });

            return Ok(new
            {
                Model = postsModel,
                Success = true,
            });
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("list/views/{postId}")]
        public async Task<IActionResult> PostViews(Guid postId)
        {
            if (UserId == null)
            {
                return Unauthorized(new
                {
                    Success = false,
                    Errors = new List<string> { "Błąd uwierzytelniania, zaloguj się ponownie i spróbuj jeszcze raz" }
                });
            }

            var postViews = await _repo.GetPostViews(postId);

            return Ok(new
            {
                Model = postViews,
                Success = true,
            });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostUpdateModel model) // dodawanie nowych encji
        {
            if (UserId == null)
            {
                return Unauthorized(new
                {
                    Success = false,
                    Errors = new List<string> { "Błąd uwierzytelniania, zaloguj się ponownie i spróbuj jeszcze raz" }
                });
            }

            Post post = _mapper.Map<Post>(model);
            post.OwnerId = (Guid)UserId;

            var result = await _repo.AddAsync(post); // przed dodaniem obiek book nie ma id (wartość domyślna 00000-00....000-000 )
                                                     // pod dodaniu obiekt ma już id i jest śledzony przez entity framework
            if (!result)
            {
                return BadRequest(new
                {
                    Success = false,
                    Errors = new List<string> { "Nie udało się dodać posta" }
                });
            }

            post = await _repo.FindAsync(post.Id);

            var postModel = new
            {
                Post = post,
                Images = post.Images.Select(x => x.ImageId),
                Owner = _mapper.Map<UserModel>(post.Owner),
                IsOwner = post.Owner != null && post.Owner.Email == UserEmail,
                HasReacted = post.Reactions.Where(x => x.AccountId == UserId).Select(x => x.Type).FirstOrDefault(),
                Group = post.Group,
                HasNotifiedAbusement = post.Abusements.Any(x => x.AccountId == UserId),
            };

            return Ok(new
            {
                Success = true,
                Errors = (List<string>)null,
                Model = postModel
            });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(Guid id, PostUpdateModel model) // dodawanie nowych encji
        {
            if (UserId == null)
            {
                return Unauthorized(new
                {
                    Success = false,
                    Errors = new List<string> { "Błąd uwierzytelniania, zaloguj się ponownie i spróbuj jeszcze raz" }
                });
            }

            var post = await _repo.FindAsync(id);

            if (post == null)
            {
                return NotFound(new
                {
                    Success = false,
                    Errors = new List<string> { "Nie znaleziono ksiązki o podanym id" },
                });
            }

            post = _mapper.Map(model, post);
            var success = await _repo.UpdateAsync(post);

            if (success == false)
            {
                return BadRequest(new
                {
                    Success = false,
                    Errors = new List<string> { "Nie udało sie zmodyfikować posta" },
                });
            }

            var postModel = new
            {
                Post = post,
                Images = post.Images.Select(x => x.ImageId),
                Owner = _mapper.Map<UserModel>(post.Owner),
                IsOwner = post.Owner != null && post.Owner.Email == UserEmail,
                Group = post.Group,
                Comments = post.Comments.Select(y => new PostCommentModel()
                {
                    Text = y.Text,
                    CommentDate = y.CommentDate,
                    Account = _mapper.Map<UserModel>(y.Account)
                }),
                Reaction = post.Reactions.Select(y => new PostReactionModel()
                {
                    Type = y.Type,
                    ReactionDate = y.ReactionDate,
                    Account = _mapper.Map<UserModel>(y.Account)
                }),
                Views = post.Views.Select(y => new PostViewModel()
                {
                    ViewDate = y.ViewDate,
                    Account = _mapper.Map<UserModel>(y.Account)
                }),
                HasNotifiedAbusement = post.Abusements.Any(x => x.AccountId == UserId),
            };

            return Ok(new
            {
                Model = postModel,
                Success = true,
                Errors = (List<string>)null,
            });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var post = await _repo.FindAsync(id);

            if (post == null)
            {
                return NotFound(new
                {
                    Success = false,
                    Errors = new List<string> { "Nie znaleziono postu o podanym Id" }
                });
            }

            if (post.OwnerId != UserId)
            {
                return Unauthorized(new
                {
                    Success = false,
                    Errors = new List<string> { "Id użytkownika i włąściciela postu nie są zgodne" }
                });
            }

            var result = await _repo.DeleteAsync(id);

            if (result == false)
            {
                return BadRequest(new
                {
                    Success = false,
                    Errors = new List<string> { "Nie udało sie usunąć postu" },
                });
            }

            return Ok(new
            {
                Success = true,
                Errors = (List<string>)null,
            });
        }

        [HttpPost]
        [Route("images/{postId}")]
        public async Task<IActionResult> AddImage(Guid postId, [FromForm] IFormFile image)
        {
            if (UserId == null)
            {
                return Unauthorized(new
                {
                    Success = false,
                    Errors = new List<string> { "Błąd uwieżytelniania, zaloguj się ponownie i spróbuj jeszcze raz" }
                });
            }

            var post = await _repo.FindAsync(postId);

            if (post == null)
            {
                return NotFound(new
                {
                    Success = false,
                    Errors = new List<string> { "Nie znaleziono postu o podanym id" },
                });
            }

            var imageId = await _repo.AddImageAsync(postId, image);

            if (imageId == Guid.Empty)
            {
                return BadRequest(new
                {
                    Success = false,
                    Errors = new List<string> { "Nie udało sie dodać zdjęcia" },
                });
            }

            return Ok(new
            {
                Model = imageId,
                Success = true,
                Errors = (List<string>)null,
            });
        }

        [HttpDelete]
        [Route("images/{imageId}")]
        public async Task<IActionResult> AddImage(Guid imageId)
        {
            var success = await _irepo.DeleteAsync(imageId);

            if (success == false)
            {
                return BadRequest(new
                {
                    Success = false,
                    Errors = new List<string> { "Nie udało sie usunąc zdjęcia" },
                });
            }

            return Ok(new
            {
                Success = true,
                Errors = (List<string>)null,
            });
        }
    }
}
