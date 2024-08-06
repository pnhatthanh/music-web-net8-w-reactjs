export default function generateTitle(title){
    return title
        .toLowerCase()
        .replace(/\s+/g, '-')
}