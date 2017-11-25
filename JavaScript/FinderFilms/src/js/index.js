import MovieList from './components/movi-list/list';

import moveService from './movie-service';

const input = document.querySelector('#input-data');

const movieList = document.querySelector('.movies');

const filter = document.querySelector('.filters');

const list = new MovieList();

input.addEventListener('input', e => {
    const searchText = e.target.value;
    if(!searchText){
        movieList.innerHTML = '';
        return;
    }
    moveService.getVideoByText(searchText)
        .then(data => {
            console.log(data);
            list.init(data);
            list.renderMovies(data.results);
            list.drawToDom(movieList);
        }
    )
    
});

filter.addEventListener('click', (e) => {
    e.preventDefault();
    const target = e.target;
    const dataAtr = target.getAttribute('data-filter');
    console.log(dataAtr);
    if(!dataAtr){
        return;
    }
    list.sort(dataAtr);
    }
)


