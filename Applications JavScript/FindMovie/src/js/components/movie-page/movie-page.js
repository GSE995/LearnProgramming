import config from '../../config'
import service from '../../movie-service'

export default class MoviePage{

    constructor(id){
        this.listWrapper = document.querySelector('.list-wrapper');
        this.movieWrapper = document.querySelector('.movie-wrapper');

        
    }

    init(data){
        this.data = this.mapData(data);
        this.html = this.getHTML(this.data);
        this.render(this.html);
    }

    async getMovie(id){
        let res = await service.getMovieById()
    }

    setMovie(data){

    }

    validData(data, id){
        for(let i = 0; i < data.length; i++){
            if(data[i].id == id){
                this.init(data[i]);
            }
        }
    }

    getHTML(data){
        let seasons = '';
        let episodes = '';
        let type = '';

        if(data.genres.length) type = `Жанр: ${data.genres.join(', ')}`;

        if(data.seasons){
            seasons = `Сезонов: ${data.seasons}`;
            episodes = `Серий: ${data.episodes}`
        }

        let html = `
            <div class="col-2 poster" style="background-image: url(${data.img}); height: 300px"> 
            </div>
            <div class="col-8">
                <h2>${data.title}</h2>
                <p>Дата релиза: ${data.date}</p>
                <p>Рейтинг ${data.popularity}</p>
                <p>${type}</p>
                <p>${seasons}</p>
                <p>${episodes}</p>
                <p>${data.overview}</p>
                <p></p>
                <p></p>
            </div>
        `;
        return html;
    }

    mapData(data){
        let type = [];
        if(data.genres){
            for(let i = 0; i < data.genres.length; i++){
                type[i] = data.genres[i].name;
            }
        }
        
        return {
            title: data.title || data.name || 'Unknown',
            img: this.setPic(data),
            date: data.first_air_date || data.release_date,
            overview: data.overview,
            popularity: data.popularity ,
            genres: type,
            episodes: data.number_of_episodes,
            seasons: data.number_of_seasons
        }
    }

    render(html){
        const element = document.createElement('div');
        element.classList.add('row');
        element.classList.add('movie');
     
        element.innerHTML = html;
    
        this.movieWrapper.style.display = 'block';
        this.listWrapper.style.display = 'none';
    
        this.movieWrapper.innerHTML = '';
    
        this.movieWrapper.appendChild(element);
    
        this.button = document.querySelector('.back');
        
        this.button.style.display = 'block';
    
        this.button.addEventListener('click', ()=>{
            this.movieWrapper.style.display = 'none';
            this.listWrapper.style.display = 'block';
        });
    }
    
    setPic(data){
        const src = data.poster_path || data.backdrop_path;
        if(!src) return config.noImagSrc;
        return config.imgUrl + src;
    }
}

