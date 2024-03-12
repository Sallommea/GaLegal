export interface PracticeArea {
  id?: number;
  title: string;
}

export interface PracticeAreaDetails {
  id?: number;
  title: string;
  content: [];
}

export interface PracticeAreaPost {
  title: string;
  content: string;
  titleEn: string;
  contentEn: string;
}

export interface PracticeAreaUpdate {
  id: number;
  title: string;
  content: string;
  titleEn: string;
  contentEn: string;
}
