import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap';
import { Policy } from 'src/app/_models/policy';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-policy-modal',
  templateUrl: './policy-modal.component.html',
  styleUrls: ['./policy-modal.component.css']
})
export class PolicyModalComponent implements OnInit {
  @Output() updateSelectedPolicy = new EventEmitter();
  editPolicy: Policy;

  constructor(public bsModalRef: BsModalRef) {
  }

  ngOnInit() {
  }

  updatePolicy() {
    this.updateSelectedPolicy.emit(this.editPolicy);
    this.bsModalRef.hide();
  }

}
