import config from '../../config';

export default function movie (data){
    const dt = mapData(data);
    const html = `
    <article class="card">
    <header class="title-header">
        <h3 class="display-2>${dt.title} ${dt.date}</h3>
    </header>
    <div class="card-block">
        <div class="img-card" style="background-image: url(${dt.img})">
            <img src=""/>
        </div>
        <div class="container">
        <p>${dt.overview}</p>
        </div>
    </div>
    </article>
    `;
    return html;
}

function mapData(data){
    return {
        title: data.title || data.name || 'Unknown',
        img: setPic(data),
        date: data.first_air_date || data.release_date,
        overview: validOverview(data.overview)       
    }
}

function setPic(data){
    const src = data.poster_path || data.backdrop_path;
    if(!src){
        return config.noImagSrc;
    }
    return config.imgUrl + src;
}

function validOverview(text){
    if(text == null){
        return 'unknown'
    }
    let mas = text.split('');
    let str = mas.slice(0, 120).join('') + '...';
    return str;
}