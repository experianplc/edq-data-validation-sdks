export enum LineContent {
    None = "none",
    Address = "address",
    Name = "name",
    Ancillery = "ancillery",
    Dataplus = "dataplus"
}

export function lookupLineContent(str?: string): LineContent {
    if (str) {
        return Object.keys(LineContent).find(key => LineContent[key as keyof typeof LineContent] === str) as LineContent | LineContent.None;    
    } else {
        return LineContent.None;
    }
}