import config from '../../config';

export default class MovieCard{

    getHTML(data){
        this.data = this.mapData(data);
        const html = `
        <article class="card">
            <a href="${this.data.id}" class="movie-link" >
            <header class="title-header">
                <h3>${this.data.title} ${this.data.year}</h3>
            </header>
            </a>
            <div class="card-block">
                <a href="${this.data.id}" class="movie-link" >
                    <div class="img-card" style="background-image: url(${this.data.img})">
                    </div>
                </a>
                <div class="container">
                    <p>${this.data.popularity}</p>
                    <p>${this.data.overview}</p>
                </div>
            </div>
        </article>
        `;
        return html;
    }

    mapData(data){
        let validyear = data.first_air_date || data.release_date;
        if(validyear){
            validyear = validyear.split('-')[0];
        }
        return {
            id: data.id,
            title: data.title || data.name || 'Unknown',
            img: this.setPic(data),
            date: data.first_air_date || data.release_date,
            year: validyear,
            popularity: data.popularity,
            overview: this.validOverview(data.overview)     
        }
    }

    setPic(data){
        const src = data.poster_path || data.backdrop_path;
        if(!src){
            return config.noImagSrc;
        }
        return config.imgUrl + src;
    }

    validOverview(text){
        if(text == null){
            return 'unknown'
        }
        let mas = text.split('');
        let str = mas.slice(0, 120).join('') + '...';
        return str;
    }
}

