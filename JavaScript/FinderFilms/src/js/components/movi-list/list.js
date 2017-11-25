import movie from '../movie/movie';
import config from '../../config';

export default class MovieList{
    init(data){
        this.data = data;
    }

    drawToDom(selector){
        this.clearList(selector);
        selector.appendChild(this.fragment);
    }
    
    renderMovies(data){
        this.fragment = document.createDocumentFragment();

        data.forEach(data => {
            const arcticle = document.createElement('div');
            arcticle.classList.add('col-6');
            arcticle.classList.add('col-md-3');
            arcticle.classList.add('movie');
            arcticle.innerHTML = movie(data);
            this.fragment.appendChild(arcticle);
        });
    }
    clearList(selector){
        selector.innerHTML = '';
    }

    sort(filter){
        const data = [...this.data.results];
        if(filter === 'reiting-max'){
            this.sortByMaxReiting(data);
        }
        if(filter === 'reiting-min'){
            this.sortByMinReiting(data);
        }
        if(filter === 'new'){
            this.sortNew(data);
        }
        if(filter === 'old'){
            this.sortOld(data);
        }
    }

    sortByMaxReiting(data){
        data.sort((a,b)=>{
            if(a.popularity < b.popularity)return 1;
            if(a.popularity > b.popularity) return -1;
        })
        this.renderMovies(data);
        this.drawToDom(document.querySelector('.movies'));
    }
    sortByMinReiting(data){
        data.sort((a,b)=>{
            if(a.popularity > b.popularity)return 1;
            if(a.popularity < b.popularity)return -1;
        })
        this.renderMovies(data);
        this.drawToDom(document.querySelector('.movies'));
    }
    sortNew(data){
        data.sort((a,b)=>{
            let aDate = new Date(a.first_air_date || a.release_date);
            let bDate = new Date(b.first_air_date || b.release_date);
            if(aDate < bDate) return 1;
            if(aDate > bDate) return -1; 
        })
        this.renderMovies(data);
        this.drawToDom(document.querySelector('.movies'));      
    }
    sortOld(data){
        data.sort((a,b)=>{
            let aDate = new Date(a.first_air_date || a.release_date);
            let bDate = new Date(b.first_air_date || b.release_date);
            if(aDate > bDate) return 1;
            if(aDate < bDate) return -1; 
        })
        this.renderMovies(data);
        this.drawToDom(document.querySelector('.movies'));   
    }
}