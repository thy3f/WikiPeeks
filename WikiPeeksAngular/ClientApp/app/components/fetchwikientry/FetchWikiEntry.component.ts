import { Component, Inject } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { WikiEntryService } from '../../services/wikientryservice.service'

@Component({
    selector: 'FetchWikiEntry',
    templateUrl: './FetchWikiEntry.component.html'
})

export class FetchWikiEntryComponent {
    public wikiEntryList: WikiEntryData[];

    constructor(public http: Http, private _router: Router, private _wikiEntryService: WikiEntryService) {
        this.getWikiEntries();
    }

    getWikiEntries() {
        this._wikiEntryService.getWikiEntries().subscribe(
            data => this.wikiEntryList = data
        )
    }

    delete(ID) {
        var ans = confirm("Do you want to delete Wiki Entry with Id: " + ID);
        if (ans) {
            this._wikiEntryService.deleteWikiEntry(ID).subscribe((data) => {
                this.getWikiEntries();
            }, error => console.error(error))
        }
    }
}

interface WikiEntryData {
    id: number;
    day: number;
    month: number;
    year: number;
    description: string;
    category: string;
    dateadded: Date;
}