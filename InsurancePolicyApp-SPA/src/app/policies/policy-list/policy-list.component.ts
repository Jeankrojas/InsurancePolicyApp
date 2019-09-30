import { Component, OnInit } from '@angular/core';
import { PolicyService } from '../../_services/policy.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Policy } from 'src/app/_models/policy';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { PolicyModalComponent } from '../policy-modal/policy-modal.component';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { PolicyModalCreateComponent } from '../policy-modal-create/policy-modal-create.component';

@Component({
  selector: 'app-policy-list',
  templateUrl: './policy-list.component.html',
  styleUrls: ['./policy-list.component.css']
})
export class PolicyListComponent implements OnInit {

  policies: Policy[];
  bsModalRef: BsModalRef;
  bsCreateModalRef: BsModalRef;

  constructor(private policyService: PolicyService, private alertify: AlertifyService,
              private modalService: BsModalService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.policies = data['policies'];
    });
  }

  editPolicyModal(policy: Policy) {
    const editPolicy = Object.assign({}, policy);
    const initialState = {
      editPolicy
    };
    this.bsModalRef = this.modalService.show(PolicyModalComponent, {initialState});
    this.bsModalRef.content.updateSelectedPolicy.subscribe((value) => {
      const policyToUpdate = value;
      this.policyService.updatePolicy(policy.id, policyToUpdate).subscribe(() => {
        this.policyService.getPolicies().subscribe((resp => {
          this.policies = resp;
        }));
        this.alertify.success('Updated successfully');
      }, error => {
        this.alertify.error(error);
      });
    });
  }

  newPolicyModal() {
      this.bsModalRef = this.modalService.show(PolicyModalCreateComponent);
      this.bsModalRef.content.newPolicy.subscribe((value) => {
      const policyToAdd = value;
      this.policyService.addPolicy(policyToAdd).subscribe(() => {
        this.policyService.getPolicies().subscribe((resp => {
          this.policies = resp;
        }));
        this.alertify.success('Added successfully');
      }, error => {
        this.alertify.error(error);
      });
    });
  }
}
