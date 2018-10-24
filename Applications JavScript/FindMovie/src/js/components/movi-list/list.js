import MovieCard from '../movie/movie-card'

export default class MovieList {

    constructor(el){
        this.el = el;
    }

    setMovies(data){
        this.data = data;
        this.renderMovies(data)
    }

    renderMovies(data){
        this.clearList();

        data.forEach(movie => {
            let card = new MovieCard(movie);
            card.renderTo(this.el);
        });
    }
    
    clearList(){
        this.el.innerHTML = '';
    }

    sort(filter){
        const data = [...this.data];

        switch(filter){
            case 'reiting-max': 
                this.sortByMaxReiting(data);
                break;
            case 'reiting-min':
                this.sortByMinReiting(data);
                break;
            case 'new':
                this.sortNew(data);
                break;
            case 'old':
                this.sortOld(data);
                break;
        }
    }

    sortByMaxReiting(data){
        data.sort((a,b)=> (a.popularity < b.popularity) ? 1 : -1);
        this.renderMovies(data);
    }

    sortByMinReiting(data){
        data.sort((a, b) => (a.popularity > b.popularity) ? 1 : -1);
        this.renderMovies(data);
    }

    sortNew(data){
        data.sort((a,b)=>{
            let aDate = new Date(a.first_air_date || a.release_date);
            let bDate = new Date(b.first_air_date || b.release_date);
            return (aDate < bDate) ? 1 : -1;
        })
        this.renderMovies(data);
    }

    sortOld(data){
        data.sort((a,b)=>{
            let aDate = new Date(a.first_air_date || a.release_date);
            let bDate = new Date(b.first_air_date || b.release_date);
            return (aDate > bDate) ? 1 : -1;
        })
        this.renderMovies(data);
    }
}