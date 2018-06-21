import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class WikiEntryService {
    myAppUrl: string = "";

    constructor(private _http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.myAppUrl = baseUrl;
    }

    getWikiEntries() {
        return this._http.get(this.myAppUrl + 'api/WikiEntry/Index')
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    getWikiEntryById(id: number) {
        return this._http.get(this.myAppUrl + "api/WikiEntry/Details/" + id)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }

    saveWikiEntry(wikiEntry) {
        return this._http.post(this.myAppUrl + 'api/WikiEntry/Create', wikiEntry)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }

    updateWikiEntry(wikiEntry) {
        return this._http.put(this.myAppUrl + 'api/WikiEntry/Edit', wikiEntry)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    deleteWikiEntry(id) {
        return this._http.delete(this.myAppUrl + "api/WikiEntry/Delete/" + id)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    errorHandler(error: Response) {
        console.log(error);
        return Observable.throw(error);
    }
}