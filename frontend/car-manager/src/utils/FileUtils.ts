export const toBase64String = (file: File) => new Promise<string>((resolve, reject) => {
        const reader = new FileReader();
        reader.readAsDataURL(file);

        reader.onload = () => {
            const result = reader.result?.toString() || '';

            return resolve(result.substring(result.lastIndexOf(',') + 1));
        };
        reader.onerror = error => reject(error);
    });