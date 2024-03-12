export interface ConsultationRequest {
  id?: number;
  firstName: string;
  lastName: string;
  email: string;
  phoneNumber: string;
  company: string;
  description: string;
  messageStatus: string;
}
export interface ConsultationRequestDetails {
  id?: number;
  firstName: string;
  lastName: string;
  email: string;
  phoneNumber: string;
  company: string;
  description: string;
}

export interface ConsultationEmail {
  id?: number;
  email: string;
  messageStatus: string;
}
export interface PaginatedRequests {
  resultList: [];
  totalPages: number;
  totalRecords: number;
}

export interface UpdateStatus {
  id: number;
  status: string;
}
