import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { FetchWikiEntryComponent } from '../fetchwikientry/FetchWikiEntry.component';
import { WikiEntryService } from '../../services/wikientryservice.service';

@Component({
    selector: 'createwikientry',
    templateUrl: './AddWikiEntry.component.html'
})

export class createwikientry implements OnInit {
    wikiEntryForm: FormGroup;
    title: string = "Create";
    id: number;
    errorMessage: any;

    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
        private _wikiEntryService: WikiEntryService, private _router: Router) {
        if (this._avRoute.snapshot.params["id"]) {
            this.id = this._avRoute.snapshot.params["id"];
        }

        this.wikiEntryForm = this._fb.group({
            id: 0,
            day: ['', [Validators.required]],
            month: ['', [Validators.required]],
            year: ['', [Validators.required]],
            description: ['', [Validators.required]],
            category: ['', [Validators.required]],
            dateadded: ['', [Validators.required]]
        })
    }

    ngOnInit() {
        if (this.id > 0) {
            this.title = "Edit";
            this._wikiEntryService.getWikiEntryById(this.id)
                .subscribe(resp => this.wikiEntryForm.setValue(resp)
                , error => this.errorMessage = error);
        }
    }

    save() {

        if (!this.wikiEntryForm.valid) {
            return;
        }

        if (this.title == "Create") {
            this._wikiEntryService.saveWikiEntry(this.wikiEntryForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/fetch-wikientry']);
                }, error => this.errorMessage = error)
        }
        else if (this.title == "Edit") {
            this._wikiEntryService.updateWikiEntry(this.wikiEntryForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/fetch-wikientry']);
                }, error => this.errorMessage = error)
        }
    }

    cancel() {
        this._router.navigate(['/fetch-wikientry']);
    }

    get day() { return this.wikiEntryForm.get('day'); }
    get month() { return this.wikiEntryForm.get('month'); }
    get year() { return this.wikiEntryForm.get('year'); }
    get description() { return this.wikiEntryForm.get('description'); }
    get category() { return this.wikiEntryForm.get('category'); }
    get dateadded() { return this.wikiEntryForm.get('dateadded'); }
    
}