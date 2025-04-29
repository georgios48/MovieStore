using Microsoft.Extensions.DependencyInjection;
using MovieStore.DL.Cache;
using MovieStore.DL.Interfaces;
using MovieStore.DL.Repositories;
using MovieStore.DL.Repositories.MongoRepositories;
using MovieStore.Models.DTO;

namespace MovieStore.DL
{
    public static class DependencyInjection
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IMovieRepository, MovieMongoRepository>();
            services.AddSingleton<IActorRepository, ActorMongoRepository>();
            // services.AddSingleton<MongoCacheDistributor>();
            services.AddSingleton<ICacheRepository<Movie>, MovieMongoRepository>();
            services.AddHostedService<MongoCachePopulator<Movie, IMovieRepository>>();
        }
    }
}
