import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap';
import { Policy } from 'src/app/_models/policy';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-policy-modal-create',
  templateUrl: './policy-modal-create.component.html',
  styleUrls: ['./policy-modal-create.component.css']
})
export class PolicyModalCreateComponent implements OnInit {
  @Output() newPolicy = new EventEmitter();
  policy: Policy;

  constructor(public bsModalRef: BsModalRef) {
  }

  ngOnInit() {
    this.policy = {
      id: 0,
      name: '',
      description: '',
      coveragePeriod: 0,
      price: 0
    };
  }

  addPolicy() {
    this.newPolicy.emit(this.policy);
    this.bsModalRef.hide();
  }
}


