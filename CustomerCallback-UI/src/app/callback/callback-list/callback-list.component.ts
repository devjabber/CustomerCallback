import { Component, OnInit, ViewChild } from '@angular/core';
import { AlertComponent } from 'src/app/common/alert/alert.component';
import { CallbackView } from 'src/app/models/CallbackView';
import { CallbackService } from 'src/app/services/callback.service';

@Component({
  selector: 'app-callback-list',
  templateUrl: './callback-list.component.html',
  styleUrls: ['./callback-list.component.css'],
})
export class CallbackListComponent implements OnInit {
  callbacks: CallbackView[] = [];
  @ViewChild(AlertComponent)
  private alertComponent!: AlertComponent;

  constructor(private callBackService: CallbackService) {}

  ngOnInit(): void {
    this.callBackService.getAllCallbacks().subscribe(
      (callbacks: CallbackView[]) => {
        this.callbacks = callbacks;
      },
      (err: any) => {
        console.log(`err => ${err}`);
        this.alertComponent.setAlert(
          'An error occured while retrieving callbacks on the Callback server.'
        );
      }
    );
  }
}
