import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AlertComponent } from 'src/app/common/alert/alert.component';
import { CallbackNew } from 'src/app/models/CallbackNew';
import { CallbackService } from 'src/app/services/callback.service';

@Component({
  selector: 'app-callback-new',
  templateUrl: './callback-new.component.html',
  styleUrls: ['./callback-new.component.css'],
})
export class CallbackNewComponent implements OnInit {
  @ViewChild('callbackNewForm') form: any;

  @ViewChild(AlertComponent)
  private alertComponent!: AlertComponent;

  callbackUser: CallbackNew = {
    firstName: '',
    lastName: '',
    mobileNumber: '',
    callbackDate: new Date(),
    callbackTime: '',
  };

  constructor(private callBackService: CallbackService) {}

  ngOnInit(): void {}

  onSubmit(callbackNewForm: NgForm) {
    if (!callbackNewForm.value) {
      this.alertComponent.setAlert('New Callback form is invalid.');
    } else {
      console.log('Form to submit');
      console.log(callbackNewForm.value);

      this.callBackService.addCallback(callbackNewForm.value).subscribe(
        (data: any) => {
          this.alertComponent.setAlert('New Callback details saved.');
          this.form.reset();
        },
        (err: any) => {
          console.log(`err => ${err}`);

          if (err?.error?.errors?.CallbackDateTime) {
            if (err.error.errors.CallbackDateTime[0]) {
              this.alertComponent.setAlert(
                err?.error?.errors?.CallbackDateTime[0]
              );
            }
          } else {
            this.alertComponent.setAlert(
              'An error occured on the server. Unable to save callback details.'
            );
          }
        }
      );
    }
  }
}
