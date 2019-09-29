import {Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import { PolicyListComponent } from './policy-list/policy-list.component';
import { ClientListComponent } from './client-list/client-list.component';
import { AuthGuard } from './_guards/auth.guard';

export const appRoutes: Routes = [
    { path: '', component: HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'policies', component: PolicyListComponent},
            { path: 'clients', component: ClientListComponent}
        ]
    },
    { path: '**', redirectTo: '', pathMatch: 'full'}
];
