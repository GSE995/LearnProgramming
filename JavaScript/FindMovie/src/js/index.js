import MovieList from './components/movi-list/list';

import moveService from './movie-service';

import MoviePage from './components/movie-page/movie-page';

const input = document.querySelector('#input-data');

const movieList = document.querySelector('.movies');

const filter = document.querySelector('.filters');

let list;
let filmtext;

input.addEventListener('input', e => {
    const searchText = e.target.value;
    filmtext = searchText;
    if(!searchText){
        movieList.innerHTML = '';
        return;
    }
    moveService.getVideoByText(searchText)
        .then(data => {
            console.log(data.results);
            list = new MovieList(data);
            list.renderMovies(data.results);
            list.drawToDom(movieList);
        }
    )
    
});

filter.addEventListener('click', (e) => {
        e.preventDefault();
        const target = e.target;
        const dataAtr = target.getAttribute('data-filter');

        if(list != null && dataAtr){
            list.sort(dataAtr);
        }
    
    }
)

movieList.addEventListener('click', e => {
    const target = e.target;
    const link = target.closest('.movie-link');
    let id;

    e.preventDefault();

    if(!link){
        return;
    }
    let moviepage = new MoviePage();
    id = link.getAttribute('href');

    moveService.getMovieById(id)
    .then(data => {
        if(data.status_code){
            moveService.getVideoByText(filmtext)
            .then(data => {
                moviepage.validData(data.results, id);
                }
            )
        }else{
            moviepage.init(data);
        }
       
    });
})

//             console.log(data);
//             // first_air_date, last_air_date
//             // массив жанров genres
//             // name
//             //number_of_episodes, number_of_seasons
//             // origin_country
//             // original_name
//             // popularity
//             // массив с инфой о сезонах seasons {air_date, episode_count, poster_path, season_number}
//             // status
//             // vote_average




