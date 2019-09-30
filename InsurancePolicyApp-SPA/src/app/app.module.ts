import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { BsDropdownModule, ModalModule } from 'ngx-bootstrap';
import { RouterModule } from '@angular/router';
import { JwtModule } from '@auth0/angular-jwt';
import { DigitOnlyModule } from '@uiowa/digit-only';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { AuthService } from './_services/auth.service';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { PolicyListComponent } from './policies/policy-list/policy-list.component';
import { ClientListComponent } from './client-list/client-list.component';
import { appRoutes } from './routes';
import { PolicyService } from './_services/policy.service';
import { AuthGuard } from './_guards/auth.guard';
import { AlertifyService } from './_services/alertify.service';
import { PolicyListResolver } from './_resolvers/policy-list.resolver';
import { PolicyModalComponent } from './policies/policy-modal/policy-modal.component';
import { PolicyModalCreateComponent } from './policies/policy-modal-create/policy-modal-create.component';

export function tokenGetter() {
   return localStorage.getItem('token');
 }

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent,
      PolicyListComponent,
      ClientListComponent,
      PolicyModalComponent,
      PolicyModalCreateComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      BsDropdownModule.forRoot(),
      RouterModule.forRoot(appRoutes),
      ModalModule.forRoot(),
      ReactiveFormsModule,
      DigitOnlyModule,
      JwtModule.forRoot({
         config: {
           tokenGetter: tokenGetter,
           whitelistedDomains: ['localhost:5000'],
           blacklistedRoutes: ['localhost:5000/api/auth']
         }
       })
   ],
   providers: [
      AuthService,
      ErrorInterceptorProvider,
      PolicyService,
      AuthGuard,
      AlertifyService,
      PolicyListResolver
   ],
   entryComponents: [
      PolicyModalComponent,
      PolicyModalCreateComponent
    ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
