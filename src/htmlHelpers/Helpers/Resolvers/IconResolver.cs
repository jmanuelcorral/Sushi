using System;
using Sushi.Helpers.Enums;

namespace Sushi.Helpers.Resolvers
{
    public static class IconManager
    {
        public static String ResolveIcon(Icon icon)
        {
            switch (icon)
            {
                case Icon.IconGlass: return "icon-glass";
                case Icon.IconMusic: return "icon-music";
                case Icon.IconSearch: return "icon-search";
                case Icon.IconEnvelope: return "icon-envelope";
                case Icon.IconHeart: return "icon-heart";
                case Icon.IconStar: return "icon-star";
                case Icon.IconStarEmpty: return "icon-star-empty";
                case Icon.IconUser: return "icon-user";
                case Icon.IconFilm: return "icon-film";
                case Icon.IconThLarge: return "icon-th-large";
                case Icon.IconTh: return "icon-th";
                case Icon.IconThList: return "icon-th-list";
                case Icon.IconOk: return "icon-ok";
                case Icon.IconRemove: return "icon-remove";
                case Icon.IconZoomIn: return "icon-zoom-in";
                case Icon.IconZoomOut: return "icon-zoom-out";
                case Icon.IconOff: return "icon-off";
                case Icon.IconSignal: return "icon-signal";
                case Icon.IconCog: return "icon-cog";
                case Icon.IconTrash: return "icon-trash";
                case Icon.IconHome: return "icon-home";
                case Icon.IconFile: return "icon-file";
                case Icon.IconTime: return "icon-time";
                case Icon.IconRoad: return "icon-road";
                case Icon.IconDownloadAlt: return "icon-download-alt";
                case Icon.IconDownload: return "icon-download";
                case Icon.IconUpload: return "icon-upload";
                case Icon.IconInbox: return "icon-inbox";
                case Icon.IconPlayCircle: return "icon-play-circle";
                case Icon.IconRepeat: return "icon-repeat";
                case Icon.IconRefresh: return "icon-refresh";
                case Icon.IconListAl: return "icon-list-alt";
                case Icon.IconLock: return "icon-lock";
                case Icon.IconFlag: return "icon-flag";
                case Icon.IconHeadphones: return "icon-headphones";
                case Icon.IconVolumeOff: return "icon-volume-off";
                case Icon.IconVolumeDown: return "icon-volume-down";
                case Icon.IconVolumeUp: return "icon-volume-up";
                case Icon.IconQrcode: return "icon-qrcode";
                case Icon.IconBarcode: return "icon-barcode";
                case Icon.IconTag: return "icon-tag";
                case Icon.IconTags: return "icon-tags";
                case Icon.IconBook: return "icon-book";
                case Icon.IconBookmark: return "icon-bookmark";
                case Icon.IconPrint: return "icon-print";
                case Icon.IconCamera: return "icon-camera";
                case Icon.IconFont: return "icon-font";
                case Icon.IconBold: return "icon-bold";
                case Icon.IconItalic: return "icon-italic";
                case Icon.IconTextHeight: return "icon-text-height";
                case Icon.IconTextWidth: return "icon-text-width";
                case Icon.IconAlignLeft: return "icon-align-left";
                case Icon.IconAlignCenter: return "icon-align-center";
                case Icon.IconAlignRight: return "icon-align-right";
                case Icon.IconAlignJustify: return "icon-align-justify";
                case Icon.IconList: return "icon-list";
                case Icon.IconIndentLeft: return "icon-indent-left";
                case Icon.IconIndentRight: return "icon-indent-right";
                case Icon.IconFacetimeVideo: return "icon-facetime-video";
                case Icon.IconPicture: return "icon-picture";
                case Icon.IconPencil: return "icon-pencil";
                case Icon.IconMapMarker: return "icon-map-marker";
                case Icon.IconAdjust: return "icon-adjust";
                case Icon.IconTint: return "icon-tint";
                case Icon.IconEdit: return "icon-edit";
                case Icon.IconShare: return "icon-share";
                case Icon.IconCheck : return "icon-check";
                case Icon.IconMove: return "icon-move";
                case Icon.IconStepBackward: return "icon-step-backward";
                case Icon.IconFastBackward: return "icon-fast-backward";
                case Icon.IconBackward: return "icon-backward";
                case Icon.IconPlay: return "icon-play";
                case Icon.IconPause: return "icon-pause";
                case Icon.IconStop: return "icon-stop";
                case Icon.IconForward: return "icon-forward";
                case Icon.IconFastForward: return "icon-fast-forward";
                case Icon.IconStepForward: return "icon-step-forward";
                case Icon.IconEject: return "icon-eject";
                case Icon.IconChevronLeft: return "icon-chevron-left";
                case Icon.IconChevronRight: return "icon-chevron-right";
                case Icon.IconPlusSign: return "icon-plus-sign";
                case Icon.IconMinusSign: return "icon-minus-sign";
                case Icon.IconRemoveSign: return "icon-remove-sign";
                case Icon.IconOkSign: return "icon-ok-sign";
                case Icon.IconQuestionSign: return "icon-question-sign";
                case Icon.IconInfoSign: return "icon-info-sign";
                case Icon.IconScreenshot: return "icon-screenshot";
                case Icon.IconRemoveCircle: return "icon-remove-circle";
                case Icon.IconOkCircle: return "icon-ok-circle";
                case Icon.IconBanCircle: return "icon-ban-circle";
                case Icon.IconArrowLeft: return "icon-arrow-left";
                case Icon.IconArrowRight: return "icon-arrow-right";
                case Icon.IconArrowUp: return "icon-arrow-up";
                case Icon.IconArrowDown: return "icon-arrow-down";
                case Icon.IconShareAlt: return "icon-share-alt";
                case Icon.IconResizeFull: return "icon-resize-full";
                case Icon.IconResizeSmall: return "icon-resize-small";
                case Icon.IconPlus: return "icon-plus";
                case Icon.IconMinus: return "icon-minus";
                case Icon.IconAsterisk: return "icon-asterisk";
                case Icon.IconExclamationSign: return "icon-exclamation-sign";
                case Icon.IconGift: return "icon-gift";
                case Icon.IconLeaf: return "icon-leaf";
                case Icon.IconFire: return "icon-fire";
                case Icon.IconEyeOpen: return "icon-eye-open";
                case Icon.IconEyeClose: return "icon-eye-close";
                case Icon.IconWarningSign: return "icon-warning-sign";
                case Icon.IconPlane: return "icon-plane";
                case Icon.IconCalendar: return "icon-calendar";
                case Icon.IconRandom: return "icon-random";
                case Icon.IconComment: return "icon-comment";
                case Icon.IconMagnet: return "icon-magnet";
                case Icon.IconChevronUp: return "icon-chevron-up";
                case Icon.IconChevronDown: return "icon-chevron-down";
                case Icon.IconRetweet: return "icon-retweet";
                case Icon.IconShoppingCart: return "icon-shopping-cart";
                case Icon.IconFolderClose: return "icon-folder-close";
                case Icon.IconFolderOpen: return "icon-folder-open";
                case Icon.IconResizeVertical: return "icon-resize-vertical";
                case Icon.IconResizeHorizontal: return "icon-resize-horizontal";
                case Icon.IconHdd: return "icon-hdd";
                case Icon.IconBullhorn: return "icon-bullhorn";
                case Icon.IconBell: return "icon-bell";
                case Icon.IconCertificate: return "icon-certificate";
                case Icon.IconThumbsUp: return "icon-thumbs-up";
                case Icon.IconThumbsDown: return "icon-thumbs-down";
                case Icon.IconHandRight: return "icon-hand-right";
                case Icon.IconHandLeft: return "icon-hand-left";
                case Icon.IconHandUp: return "icon-hand-up";
                case Icon.IconHandDown: return "icon-hand-down";
                case Icon.IconCircleArrowRight: return "icon-circle-arrow-right";
                case Icon.IconCircleArrowLeft: return "icon-circle-arrow-left";
                case Icon.IconCircleArrowUp: return "icon-circle-arrow-up";
                case Icon.IconCircleArrowDown: return "icon-circle-arrow-down";
                case Icon.IconGlobe: return "icon-globe";
                case Icon.IconWrench: return "icon-wrench";
                case Icon.IconTasks: return "icon-tasks";
                case Icon.IconFilter: return "icon-filter";
                case Icon.IconBriefcase: return "icon-briefcase";
                case Icon.IconFullscreen: return "icon-fullscreen"; 
            }
            return "";
        }

        public static String ResolveColor(IconColor color)
        {
            switch (color)
            {
                    case IconColor.Black:
                    return String.Empty;
                case IconColor.White:
                    return "icon-white";
            }
            return String.Empty;
        }
    }
}