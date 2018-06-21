import { NgModule } from '@angular/core';
import { WikiEntryService } from './services/wikientryservice.service';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchWikiEntryComponent } from './components/fetchwikientry/FetchWikiEntry.component';
import { createwikientry } from './components/addwikientry/AddWikiEntry.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        FetchWikiEntryComponent,
        createwikientry
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'fetch-wikientry', component: FetchWikiEntryComponent },
            { path: 'create-wikientry', component: createwikientry },
            { path: 'wikientry/edit/:id', component: createwikientry },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [WikiEntryService]
})
export class AppModuleShared {
}
