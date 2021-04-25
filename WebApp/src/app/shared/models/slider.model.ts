export interface RootObject {
    title: string;
    text: string;
    comment: boolean;
    categoryId: number;
    like: number;
    dislike: number;
    view: number;
    videoLink?: any;
    photos?: any;
    category?: any;
    id: number;
    softDeleted: boolean;
    createdAt: Date;
    modifiedAt?: any;
}