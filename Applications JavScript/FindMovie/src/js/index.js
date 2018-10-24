import '@babel/polyfill'
import config from './config'

import MovieList from './components/movi-list/list'

import MoveService from './movie-service'

import MoviePage from './components/movie-page/movie-page'


const input = document.querySelector('#input-data');
const movieList = document.querySelector('.movies');
const filter = document.querySelector('.filters');

let list;
let filmtext;

let movieService = new MoveService(config);

async function searchMovies(e) {
    const searchText = e.target.value;
    filmtext = searchText;
    if(!searchText){
        movieList.innerHTML = '';
        return;
    }

    let data = await movieService.getByName(searchText);
    
    list = new MovieList(data);
    list.renderMovies(data.results);
    list.drawToDom(movieList);
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

    if(list != null && dataAtr){
        list.sort(dataAtr);
    }
}



input.addEventListener('input', searchMovies)
movieList.addEventListener('click', openMoviePage)
filter.addEventListener('click', sortMovie)





