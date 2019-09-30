import {Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import { PolicyListComponent } from './policies/policy-list/policy-list.component';
import { ClientListComponent } from './client-list/client-list.component';
import { AuthGuard } from './_guards/auth.guard';
import { PolicyListResolver } from './_resolvers/policy-list.resolver';

export const appRoutes: Routes = [
    { path: '', component: HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'policies', component: PolicyListComponent,  resolve: {policies: PolicyListResolver}},
            { path: 'clients', component: ClientListComponent}
        ]
    },
    { path: '**', redirectTo: '', pathMatch: 'full'}
];
