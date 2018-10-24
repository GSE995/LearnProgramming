import '@babel/polyfill'
import config from './config'

import MovieList from './components/movi-list/list'
import MoveService from './movie-service'
import MoviePage from './components/movie-page/movie-page'

const input = document.querySelector('#input-data');
const movieListEl = document.querySelector('.movies');
const filter = document.querySelector('.filters');

let filmtext;

let movieService = new MoveService(config);
let movieList = new MovieList(movieListEl);

input.addEventListener('input', searchMovies)
movieListEl.addEventListener('click', openMoviePage)
filter.addEventListener('click', sortMovie)

async function searchMovies(e) {
    const searchText = e.target.value;
    filmtext = searchText;
    if(!searchText){
        movieList.clearList();
        return;
    }

    let data = await movieService.getByName(searchText);
    movieList.setMovies(data.results);
}

async function openMoviePage(e){
    e.preventDefault();

    const target = e.target;
    const link = target.closest('.movie-link');

    if(!link) return;
    let id = link.getAttribute('href');

    let moviepage = new MoviePage();

    let data = await movieService.getById(id)

    if(data.status_code){
        let data = await movieService.getByName(filmtext);
        moviepage.validData(data.results, id);
    }else{
        moviepage.init(data);
    }
}

function sortMovie(e){
    e.preventDefault();
    const target = e.target;
    const dataAtr = target.getAttribute('data-filter');

    if(movieList.data != null && dataAtr){
        movieList.sort(dataAtr);
    }
}







