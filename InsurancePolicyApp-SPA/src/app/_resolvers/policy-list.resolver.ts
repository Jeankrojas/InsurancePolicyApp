import {Injectable} from '@angular/core';
import {Policy} from '../_models/policy';
import {Resolve, Router, ActivatedRouteSnapshot} from '@angular/router';
import { PolicyService } from '../_services/policy.service';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class PolicyListResolver implements Resolve<Policy[]> {
    constructor(private policyService: PolicyService, private router: Router,
        private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Policy[]> {
        return this.policyService.getPolicies().pipe(
            catchError(error => {
                this.alertify.error('Problem retrieving data');
                this.router.navigate(['/home']);
                return of(null);
            })
        );
    }
}