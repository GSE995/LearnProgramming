import config from './config';

function getVideoByText(text){
    if(!text){
        return;
    }
    return fetch(config.searchMovieUrl + text).then(r => {
        let a = r.json();
        console.log(a);
        return a;
    });
}

function getMovieById(id){
    const url = `${config.baseMovieUrl}${config.queryMovie}${id}${config.apiKey}`;

    return fetch(url)
    .then(r => r.json());
}

export default {
    getVideoByText,
    getMovieById
}