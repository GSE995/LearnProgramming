export default class MovieService {
    constructor(config){
        this.config = config;
    }

    async getByName(name){
        if(!name) return;
        let result = await fetch(this.config.searchMovieUrl + name)
        return result.json();
    }

    async getById(id){
        let url = `${this.config.baseMovieUrl}${this.config.queryMovie}${id}${this.config.apiKey}`;
        let result = await fetch(url)
        return result.json();
    }
}
