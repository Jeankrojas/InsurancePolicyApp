import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Policy } from '../_models/policy';

@Injectable({
  providedIn: 'root'
})
export class PolicyService {

    baseUrl = environment.apiUrl;

    constructor(private http: HttpClient) { }

    getPolicies(): Observable<Policy[]> {
      return this.http.get<Policy[]>(this.baseUrl + 'policies');
    }

    getPolicy(id): Observable<Policy> {
      return this.http.get<Policy>(this.baseUrl + 'policies/' + id);
    }

    updatePolicy(id: number, policy: Policy) {
      return this.http.put(this.baseUrl + 'policies/' + id, policy);
    }

    addPolicy(policy: Policy) {
      return this.http.post(this.baseUrl + 'policies/', policy);
    }
}
